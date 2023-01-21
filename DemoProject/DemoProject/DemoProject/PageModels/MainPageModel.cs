using System;
using System.Windows.Input;
using DemoProject.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Xamarin.Forms;

namespace DemoProject.PageModels
{
    public class MainPageModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IDefaultBackgroundService _backgroundService;
        
        public MainPageModel(
            IDefaultBackgroundService backgroundService, 
            IMvxNavigationService navigationService)
        {
            _backgroundService = backgroundService;
            _navigationService = navigationService;
            StartBackgroundServiceCommand = new Command(ExecuteStartBackgroundServiceCommand);
            StopBackgroundServiceCommand = new Command(ExecuteStopBackgroundServiceCommand);
            OpenWebViewCommand = new MvxCommand(ExecuteOpenWebViewCommand);
        }
        
        
        public ICommand StartBackgroundServiceCommand { get; }
        public ICommand StopBackgroundServiceCommand { get; }
        public ICommand OpenWebViewCommand { get; }
        
        
        private void ExecuteStartBackgroundServiceCommand(object obj)
        {
            _backgroundService.Start();
        }
        
        private void ExecuteStopBackgroundServiceCommand(object obj)
        {
            _backgroundService.Stop();
        }
     
        private void ExecuteOpenWebViewCommand()
        {
            _navigationService.Navigate<WebViewPageModel>();
        }

    }
}

