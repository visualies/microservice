using BaseService.Core.Entities;
using BaseService.Core.QueryParams;

namespace BaseService.Core.Repositories
{
    public interface IExampleRepository : IRepositoryBase<Example, ExampleQuery, ulong>
    {

    }
}
