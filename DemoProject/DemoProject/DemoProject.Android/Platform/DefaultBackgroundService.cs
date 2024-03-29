﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using DemoProject.Services;
using MvvmCross;

namespace DemoProject.Droid.Platform
{
    [Service]
    public class DefaultBackgroundService : BaseBackgroundService, IDefaultBackgroundService
    {
        private readonly DefaultNotificationService _notificationService;

        public DefaultBackgroundService()
        {
            _notificationService = new DefaultNotificationService();
        }
        public CancellationTokenSource TokenSource { get; private set; }

        protected override Type ServiceType => typeof(DefaultBackgroundService);

        public override void Start()
        {
            TokenSource = new CancellationTokenSource();
            base.Start();
        }

        public override void Stop()
        {
            base.Stop();
            TokenSource?.Cancel();
        }

        protected override Notification BuildNotification()
        {
            return _notificationService.BuildNotification();
        }

        protected override Task Work()
        {
            var instance = Mvx.IoCProvider.Resolve<IDefaultBackgroundService>();//Replace with your IOC container
            var service = Mvx.IoCProvider.Resolve<IWorkService>();

            return Task.Run(async () =>
            {
                do
                {
                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("=============");
                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine(DateTime.Now.ToLongTimeString());
                    System.Diagnostics.Debug.WriteLine("");
                    System.Diagnostics.Debug.WriteLine("=============");
                    System.Diagnostics.Debug.WriteLine("");

                    await service.Do();
                    await Task.Delay(TimeSpan.FromSeconds(10));

                    var token = instance.TokenSource.Token;
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                } while (true);

                base.Stop();
            });
        }
    }
}