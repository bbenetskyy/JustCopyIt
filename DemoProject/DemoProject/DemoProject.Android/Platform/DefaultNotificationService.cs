using System;
using Android.App;

namespace DemoProject.Droid.Platform
{
    public class DefaultNotificationService : BaseNotificationService
    {
        public DefaultNotificationService() : base("6061")
        {
        }

        public Notification BuildNotification()
        {
            return base.BuildNotification("Background service", "Working.......");
        }
    }
    public class MyNotification : BaseNotificationService
    {
        public MyNotification() : base("6062")
        {
        }
        public void Show()
        {
            base.Notify(base.BuildNotification("My notification", DateTime.Now.ToLongTimeString()));
        }
    }
}

