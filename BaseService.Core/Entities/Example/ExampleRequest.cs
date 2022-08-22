using Microsoft.AspNetCore.Mvc;

namespace BaseService.Core.Entities.Example
{
    public class ExampleRequest : RequestBase
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; }

        [FromQuery(Name = "last_name")]
        public string LastName { get; set; }

    }
}
