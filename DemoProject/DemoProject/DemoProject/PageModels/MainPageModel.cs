using System;
using System.Windows.Input;
using DemoProject.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using Plugin.LocalNotification.EventArgs;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DemoProject.PageModels
{
    public class MainPageModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IDefaultBackgroundService _backgroundService;
        
        public MainPageModel(
            IDefaultBackgroundService backgroundService, 
            IMvxNavigationService navigationService)
        {
            _backgroundService = backgroundService;
            _navigationService = navigationService;
            
            StartBackgroundServiceCommand = new Command(ExecuteStartBackgroundServiceCommand);
            StopBackgroundServiceCommand = new Command(ExecuteStopBackgroundServiceCommand);
            OpenWebViewCommand = new MvxCommand(ExecuteOpenWebViewCommand);
        }


        public ICommand StartBackgroundServiceCommand { get; }
        public ICommand StopBackgroundServiceCommand { get; }
        public ICommand OpenWebViewCommand { get; }
        
        public override async void ViewAppeared()
        {
            if (await LocalNotificationCenter.Current.AreNotificationsEnabled() == false)
            {
                //this should work according to docs, but it doesn't work for me on Android 13
                //that's why I request them also at MainActivity->OnStart
                var result = await LocalNotificationCenter.Current.RequestNotificationPermission();
            }

            //this will be called from BG Service later
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Test Description",
                Title = "Notification!",
                ReturningData = "Dummy Data",
                NotificationId = 1337,
                Schedule = 
                {
                    NotifyTime = DateTime.Now.AddSeconds(5) // Used for Scheduling local notification, if not specified notification will show immediately.
                },
                Android =
                {
                    IconLargeName = new AndroidIcon("my_icon"),
                    IconSmallName = new AndroidIcon("notification_icon")
                }
            };

            await LocalNotificationCenter.Current.Show(notification);
        }
        
        
        private void ExecuteStartBackgroundServiceCommand(object obj)
        {
            _backgroundService.Start();
        }
        
        private void ExecuteStopBackgroundServiceCommand(object obj)
        {
            _backgroundService.Stop();
        }
     
        private void ExecuteOpenWebViewCommand()
        {
            _navigationService.Navigate<WebViewPageModel>();
        }
    }
}

