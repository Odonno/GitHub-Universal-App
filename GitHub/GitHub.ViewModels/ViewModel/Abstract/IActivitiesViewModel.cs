﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using Octokit;

namespace GitHub.ViewModels.ViewModel.Abstract
{
    public interface IActivitiesViewModel
    {
        ObservableCollection<Activity> Activities { get; }

        ICommand SearchCommand { get; }
    }
}