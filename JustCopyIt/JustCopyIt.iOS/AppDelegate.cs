using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace JustCopyIt.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxFormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // global::Xamarin.Forms.Forms.Init();
            // LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}