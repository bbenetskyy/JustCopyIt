using JustCopyIt.Services;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace JustCopyIt
{
    public class AppConfiguration : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MainPageModel>();
            
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<ILogger, Logger>();
        }
    }
}