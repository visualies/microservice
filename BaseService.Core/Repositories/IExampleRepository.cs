using BaseService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseService.Core.Repositories
{
    public interface IExampleRepository : IBaseRepository<Example, string>
    {
        Example FindByName(string exampleName);
    }
}
