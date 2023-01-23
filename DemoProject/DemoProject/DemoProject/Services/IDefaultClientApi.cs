using System;
using Refit;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DemoProject.Services
{
    public interface IDefaultClientApi
    {
        [Post("/api/bogdan_api_fg_task")]
        Task<string> Do([Body]DefaultRequest content);
    }
    public class DefaultRequest
    {
        [JsonProperty("device_guid")]
        public Guid DeviceGuid { get; set; }
    }
}

