using System;
using System.Threading.Tasks;
using DemoProject.PageModels;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.Navigation;
using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoProject
{
    public partial class App : Application
    {
        private IMvxNavigationService _navigationService;

        public App ()
        {
            InitializeComponent();
            
            // Local Notification tap event listener
            LocalNotificationCenter.Current.NotificationActionTapped += OnNotificationActionTapped;
        }

        public IMvxNavigationService NavigationService => _navigationService ??= Mvx.IoCProvider.Resolve<IMvxNavigationService>();

        protected override void OnStart()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }

        private void OnNotificationActionTapped(NotificationEventArgs e)
        {
            // your code goes here
            LocalNotificationCenter.Current.ClearAll();
            NavigationService.Navigate<NotificationPageModel, NotificationParams>(new NotificationParams()
            {
                Information = e.Request.Title,
                Data = e.Request.ReturningData
            });
        }

        private static void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs unobservedTaskExceptionEventArgs)
        {
            var newExc = new Exception(nameof(TaskSchedulerOnUnobservedTaskException), unobservedTaskExceptionEventArgs.Exception);
            LogUnhandledException(newExc);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var newExc = new Exception(nameof(CurrentDomainOnUnhandledException), unhandledExceptionEventArgs.ExceptionObject as Exception);
            LogUnhandledException(newExc);
        }

        private static void LogUnhandledException(Exception exception)
        {
            if (Mvx.IoCProvider.CanResolve<ILogger>())
            {
                var logger = Mvx.IoCProvider.Resolve<ILogger>();
                logger.LogError(exception, exception.Message);
            }
        }
    }
}

