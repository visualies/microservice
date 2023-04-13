using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaseService.Core.QueryParams
{
    public class ExampleQuery : QueryBase
    {
        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
