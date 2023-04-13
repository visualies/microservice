using BaseService.Core.Requests;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseService.Api.Requests.Update
{
    public class ExampleUpdateRequest : RequestBase
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}
