using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Entities.RequestEntity
{
    public class ExampleRequest : RequestBase
    {
        public string name { get; set; }
        public string description { get; set; }
    }
}
