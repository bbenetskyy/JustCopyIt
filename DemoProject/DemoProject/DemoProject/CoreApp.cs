using System;
using System.Net.Http;
using DemoProject.PageModels;
using DemoProject.Services;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Refit;

namespace DemoProject
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            RegisterSingletons();
            RegisterAppStart<MainPageModel>();
        }
        private void RegisterSingletons()
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IDefaultClientApi>(() =>
            {
                HttpMessageHandler handler = new HttpClientHandler();
                var httpClientNotAuthorised = new HttpClient(new LoggerHttpMessageHandler(handler));
                httpClientNotAuthorised.BaseAddress = new Uri("https://ccc-manager-dev.q-prox.com:8443");
                return RestService.For<IDefaultClientApi>(httpClientNotAuthorised, refitSettings);
            });
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IWorkService, WorkService>();
        }
    }
}

