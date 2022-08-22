using BaseService.Core.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace BaseService.Core.Entities
{
    public class RequestBase
    {
        [ReservedParameter]
        [FromQuery(Name = "expand")]
        public string ExpandRequestOption { get; set; }

        [ReservedParameter]
        [FromQuery(Name = "limit")]
        public int? LimitRequestOption { get; set; }

        [ReservedParameter]
        [FromQuery(Name = "page")]
        public int? PageRequestOption { get; set; }
    }
}
