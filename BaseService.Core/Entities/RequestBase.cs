﻿using Microsoft.AspNetCore.Mvc;

namespace BaseService.Core.Entities
{
    public class RequestBase
    {
        [FromQuery(Name = "expand")]
        public string Expand { get; set; }

        [FromQuery(Name = "limit")]
        public int? Limit { get; set; }

        [FromQuery(Name = "page")]
        public int? Page { get; set; }
    }
}
