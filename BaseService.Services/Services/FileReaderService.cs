using BaseService.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BaseService.Services.Services
{
    public static class FileReaderService
    {
        public static BaseConfig GetConfig()
        {
            var file = "./Config/Config.json";
            var data = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<BaseConfig>(data);
        }

        public static MessagingConfig GetMessagingConfig()
        {
            var file = "./Config/MessagingConfig.json";
            var data = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<MessagingConfig>(data);
        }
    }
}
