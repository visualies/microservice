using System;
using System.Collections.Generic;
using System.Text;

namespace BaseService.Core.Entities
{
    public abstract class Example
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
