using BaseService.Core.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaseService.Core.QueryParams
{
    public class QueryBase
    {
        [ReservedParameter]
        public string Expand { get; set; }

        [ReservedParameter]
        public int? Limit { get; set; }

        [ReservedParameter]
        public int? Page { get; set; }
    }
}
