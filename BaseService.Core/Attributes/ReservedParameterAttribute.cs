using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Attributes
{
    public class ReservedParameterAttribute : Attribute
    {
        public bool IsReserved { get; set; }
    }
}
