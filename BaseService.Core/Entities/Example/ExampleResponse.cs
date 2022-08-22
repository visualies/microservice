using System.Text.Json.Serialization;

namespace BaseService.Core.Entities.Example
{
    public class ExampleResponse
    {
        [JsonPropertyName("id")]
        public ulong Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}
