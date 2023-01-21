using MvvmCross.ViewModels;

namespace DemoProject.PageModels
{
	public class NotificationParams
	{
        public string Information { get; set; }
        public string Data { get; set; }
	}
    public class NotificationPageModel : MvxViewModel<NotificationParams>
    {
        public override void Prepare(NotificationParams parameter)
        {
            Information = parameter.Information;
            NotificationData = parameter.Data;
        }

        private string _information;
        public string Information
        {
            get => _information;
            set => SetProperty(ref _information, value);
        }

        private string _notificationData;
        public string NotificationData
        {
            get => _notificationData;
            set => SetProperty(ref _notificationData, value);
        }
    }
}

