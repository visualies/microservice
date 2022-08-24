using BaseService.Core.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace BaseService.Core.Requests
{
    public class RequestBase
    {
        [ReservedParameter]
        [FromQuery(Name = "expand")]
        public string Expand { get; set; }

        [ReservedParameter]
        [FromQuery(Name = "limit")]
        public int? Limit { get; set; }

        [ReservedParameter]
        [FromQuery(Name = "page")]
        public int? Page { get; set; }
    }
}
