using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Entities.RequestEntity
{
    public class RequestBase
    {
        public string expand { get; set; }
        public int? limit { get; set; }
        public int? page { get; set; }
    }
}
