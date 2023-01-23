using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DemoProject.Services
{
    public class WorkService : IWorkService
    {
        private readonly IDefaultClientApi _defaultClientApi;
        public WorkService(IDefaultClientApi defaultClientApi)
        {
            _defaultClientApi = defaultClientApi;
            DeviceId = Guid.NewGuid();
        }
        public static Guid DeviceId { get; set; }

        public async Task Do()
        {
            try
            {
                var response = await _defaultClientApi.Do(new DefaultRequest()
                {
                    DeviceGuid = DeviceId
                });

                Debug.WriteLine($"Response : {response}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{ex.Message} {Environment.NewLine} {ex.StackTrace}");
            }
        }
    }

    public interface IWorkService
    {
        Task Do();
    }
}

