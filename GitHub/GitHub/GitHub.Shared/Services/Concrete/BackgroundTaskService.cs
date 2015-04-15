﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GitHub.Services.Abstract;
using Windows.ApplicationModel.Background;

namespace GitHub.Services.Concrete
{
    public class BackgroundTaskService : IBackgroundTaskService
    {
        public Dictionary<string, string> Tasks
        {
            get
            {
                return new Dictionary<string, string>
                {
                    {"NotificationsBackgroundTask", "GitHub.Tasks"}
                };
            }
        }


        public async Task RegisterTasksAsync()
        {
            foreach (var kvTask in Tasks)
            {
                foreach (var task in BackgroundTaskRegistration.AllTasks)
                {
                    if (task.Value.Name == kvTask.Key)
                        break;
                }

                await RegisterTaskAsync(kvTask.Key, kvTask.Value);
            }
        }

        private async Task RegisterTaskAsync(string taskName, string taskNamespace)
        {
            var requestAccess = await BackgroundExecutionManager.RequestAccessAsync();

            if (requestAccess == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity || 
                requestAccess == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity)
            {
                var taskBuilder = new BackgroundTaskBuilder
                {
                    Name = taskName,
                    TaskEntryPoint = string.Format("{0}.{1}", taskNamespace, taskName)
                };
                taskBuilder.SetTrigger(new TimeTrigger(15, false));

                var registration = taskBuilder.Register();
            }
        }
    }
}
