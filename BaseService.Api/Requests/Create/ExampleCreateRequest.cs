using BaseService.Core.Requests;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace BaseService.Api.Requests.Create
{
    public class ExampleCreateRequest : RequestBase
    {
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}
