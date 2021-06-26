using BaseService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Repositories
{
    public interface IExampleRepository : IBaseRepository<Example, string>
    {
        Task<Example> FindByNameAsync(string exampleName);
    }
}
