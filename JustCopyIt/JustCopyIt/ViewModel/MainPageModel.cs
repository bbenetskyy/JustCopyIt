using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace JustCopyIt
{
    public class MainPageModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainPageModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            OpenWebViewCommand = new MvxCommand(ExecuteOpenWebViewCommand);
        }

        public ICommand OpenWebViewCommand { get; }
        
        private void ExecuteOpenWebViewCommand()
        {
            _navigationService.Navigate<WebViewPageModel>();
        }
    }
}