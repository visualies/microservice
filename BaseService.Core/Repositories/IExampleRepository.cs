using BaseService.Core.Entities;
using BaseService.Core.Requests;

namespace BaseService.Core.Repositories
{
    public interface IExampleRepository : IRepositoryBase<Example, ExampleRequest, ulong>
    {

    }
}
