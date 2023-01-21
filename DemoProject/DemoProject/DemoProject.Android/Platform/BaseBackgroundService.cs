using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using DemoProject.Services;
using MvvmCross;
using MvvmCross.Base;
using static Android.Provider.CalendarContract;

namespace DemoProject.Droid.Platform
{
    public abstract class BaseBackgroundService : Service

    {
        const int SERVICE_ID = 6060;

        protected virtual Context Context => Android.App.Application.Context;

        protected abstract Type ServiceType { get; }

        protected IBinder Binder { get; private set; }
        public virtual void Start()
        {
            var intent = new Intent(Context, ServiceType);

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                Context.StartForegroundService(intent);
            }
            else
            {
                Context.StartService(intent);
            }
        }

        public virtual void Stop()
        {
            var intent = new Intent(Context, ServiceType);
            if (intent != null)
            {
                Context.StopService(intent);
            }
        }

        public override IBinder OnBind(Intent intent)
        {
            if (intent != null)
            {
                Binder = new DefaultBinder(this);
                return Binder;
            }
            else
                return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            if (intent != null)
            {
                StartForeground(SERVICE_ID, BuildNotification());
                Task.Run(async () =>
                {
                    await Work();
                });
            }
            return StartCommandResult.Sticky;
        }

        protected abstract Notification BuildNotification();

        protected abstract Task Work();
    }

    public class DefaultBinder : Binder
    {
        public BaseBackgroundService Service { get; private set; }

        public DefaultBinder(BaseBackgroundService service)
        {
            Service = service;
        }
        public BaseBackgroundService GetLocationServiceBinder()
        {
            return Service;
        }
    }
}

