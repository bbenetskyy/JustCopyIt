using System;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using Plugin.LocalNotification;

namespace DemoProject.Droid
{
    [Activity(Label = "DemoProject", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : MvxFormsAppCompatActivity<Setup, CoreApp, App>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            LocalNotificationCenter.CreateNotificationChannel();
            
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            LocalNotificationCenter.NotifyNotificationTapped(Intent);
        }
        
        protected override void OnStart()
        {
            base.OnStart();
            
            const int requestLocationId = 0;
            string[] notificationPermission =
            {
                Manifest.Permission.PostNotifications
            };

            if ((int)Build.VERSION.SdkInt < 33) return;

            if (CheckSelfPermission(Manifest.Permission.PostNotifications) != Permission.Granted)
            {
                RequestPermissions(notificationPermission, requestLocationId);
            }
        }
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnNewIntent(Intent intent)
        {
            LocalNotificationCenter.NotifyNotificationTapped(intent);
            base.OnNewIntent(intent);
        }
    }
}
