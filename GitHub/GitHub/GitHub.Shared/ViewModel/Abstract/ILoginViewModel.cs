﻿#if WINDOWS_PHONE_APP
using Windows.ApplicationModel.Activation;
#endif

namespace GitHub.ViewModel.Abstract
{
    public interface ILoginViewModel
    {
        string Username { get; set; }
        string Password { get; set; }

        void Login();

#if WINDOWS_PHONE_APP
        void Finalize(WebAuthenticationBrokerContinuationEventArgs args);
#endif
    }
}