using System;
using Android.Util;
using DemoProject.Droid.Platform;
using DemoProject.Services;
using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.IoC;
using Serilog;
using Serilog.Extensions.Logging;

namespace DemoProject.Droid
{
    public class Setup : MvxFormsAndroidSetup<CoreApp, App>
    {
        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override ILoggerFactory CreateLogFactory()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        /// <summary>
        /// Initialize IoC Container and register platform dependencies
        /// </summary>
        /// <returns></returns>
        protected override IMvxIoCProvider InitializeIoC()
        {
            var ioc = base.InitializeIoC();
            ioc.LazyConstructAndRegisterSingleton<IDefaultBackgroundService, DefaultBackgroundService>();
            return ioc;
        }
    }
}

