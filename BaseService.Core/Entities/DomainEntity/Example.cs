using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BaseService.Core.Entities.DomainEntity
{
    public class Example
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
