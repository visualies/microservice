using BaseService.Core.Entities.DataEntity;
using BaseService.Core.Entities.RequestEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Repositories
{
    public interface IExampleRepository : IRepositoryBase<Example, ExampleRequest, ulong>
    {

    }
}
