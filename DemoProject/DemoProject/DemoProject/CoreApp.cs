using System;
using DemoProject.PageModels;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.ViewModels;

namespace DemoProject
{
	public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainPageModel>();
        }
    }
}

