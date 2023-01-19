using Android.App;
using Android.Content;
using Android.Content.PM;
using Plugin.LocalNotification;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;

namespace JustCopyIt.Droid
{
    [Activity(
        Label = "JustCopyIt", 
        Theme = "@style/MainTheme",
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            NotificationCenter.CreateNotificationChannel();
            base.OnCreate(savedInstanceState);
        
            NotificationCenter.NotifyNotificationTapped(Intent);
        }

        protected override void OnNewIntent(Intent intent)
        {
            NotificationCenter.NotifyNotificationTapped(intent);
            base.OnNewIntent(intent);
        }
    }
}