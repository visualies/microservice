using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace BaseService.Core.Requests
{
    public class ExampleRequest : RequestBase
    {
        [FromQuery(Name = "name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [FromQuery(Name = "last_name")]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

    }
}
