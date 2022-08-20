using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseService.Core.Entities.RequestEntity
{
    public class ExampleRequest : RequestBase
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}
