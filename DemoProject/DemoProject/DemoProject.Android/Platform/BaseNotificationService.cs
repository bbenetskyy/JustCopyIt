using System;
using Android.App;
using Android.Content;
using Android.OS;

namespace DemoProject.Droid.Platform
{
    public abstract class BaseNotificationService
    {
        readonly string _notificationChannelId;

        public BaseNotificationService(string notificationChanellId)
        {
            _notificationChannelId = notificationChanellId;
        }

        private Context Context => Xamarin.Essentials.Platform.CurrentActivity;

        protected virtual Notification BuildNotification(string title, string contentText)
        {
            // Building intent
            var intent = new Intent(Context, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.SingleTop);
            intent.PutExtra("Title", "Message");

            var pendingIntent = PendingIntent.GetActivity(Context, 0, intent, Build.VERSION.SdkInt >= BuildVersionCodes.S
               ? PendingIntentFlags.Immutable  // if don't work should be Mutable
               : PendingIntentFlags.UpdateCurrent); //also can be OneShot

            var notifBuilder = new AndroidX.Core.App.NotificationCompat.Builder(Context, _notificationChannelId)
                .SetContentTitle(title)
                .SetContentText(contentText)
                .SetSmallIcon(Resource.Mipmap.icon)
                .SetOngoing(true)
                .SetContentIntent(pendingIntent);

            // Building channel if API verion is 26 or above
            if (global::Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel notificationChannel = new NotificationChannel(_notificationChannelId, "XXX", NotificationImportance.High);
                notificationChannel.Importance = NotificationImportance.High;
                notificationChannel.EnableLights(true);
                notificationChannel.EnableVibration(true);
                notificationChannel.SetShowBadge(true);

                var notifManager = Context.GetSystemService(Context.NotificationService) as NotificationManager;
                if (notifManager != null)
                {
                    notifBuilder.SetChannelId(_notificationChannelId);
                    notifManager.CreateNotificationChannel(notificationChannel);
                }
            }
            return notifBuilder.Build();
        }

        protected virtual void Notify(Notification notification)
        {
            NotificationManager notificationManager = (NotificationManager)Context.GetSystemService(Context.NotificationService);
            notificationManager.Notify(777, notification);

        }

        protected virtual void CancelNotification()
        {
            NotificationManager notificationManager = (NotificationManager)Context.GetSystemService(Context.NotificationService);
            notificationManager.Cancel(777);
        }
    }
}

