using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;

namespace JustCopyIt
{
    public class MainPageModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainPageModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            NotificationCenter.Current.NotificationTapped += OnNotificationTapped;

            OpenWebViewCommand = new MvxCommand(ExecuteOpenWebViewCommand);
        }

        public override void ViewAppeared()
        {
            //this will be called from BG Service later
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Test Description",
                Title = "Notification!",
                ReturningData = "Dummy Data",
                NotificationId = 1337,
                Android =
                {
                    IconSmallName =
                    {
                        ResourceName = "check"
                    }
                }
            };

            NotificationCenter.Current.Show(notification);
        }

        public ICommand OpenWebViewCommand { get; }
        
        private void ExecuteOpenWebViewCommand()
        {
            _navigationService.Navigate<WebViewPageModel>();
        }

        private void OnNotificationTapped(NotificationEventArgs e)
        {
            NotificationCenter.Current.ClearAll();
            _navigationService.Navigate<NotificationPageModel, NotificationParams>(new NotificationParams()
            {
                Information = e.Request.Title,
                Data = e.Request.ReturningData
            });
        }
    }
}