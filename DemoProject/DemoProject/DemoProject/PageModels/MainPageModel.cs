using System;
using System.Windows.Input;
using DemoProject.Services;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace DemoProject.PageModels
{
    public class MainPageModel : MvxViewModel
    {
        private readonly IDefaultBackgroundService _backgroundService;
        public MainPageModel(IDefaultBackgroundService backgroundService)
        {
            _backgroundService = backgroundService;
            StartBackgroundServiceCommand = new Command(ExecuteStartBackgroundServiceCommand);
            StopBackgroundServiceCommand = new Command(ExecuteStopBackgroundServiceCommand);
        }

        private void ExecuteStartBackgroundServiceCommand(object obj)
        {
            _backgroundService.Start();
        }
        private void ExecuteStopBackgroundServiceCommand(object obj)
        {
            _backgroundService.Stop();
        }

        public ICommand StartBackgroundServiceCommand { get; }
        public ICommand StopBackgroundServiceCommand { get; }
    }
}

