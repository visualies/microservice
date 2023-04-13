using BaseService.Core.Entities;
using BaseService.Core.QueryParams;

namespace BaseService.Core.Services
{
    public interface IExampleService : IServiceBase<Example, ExampleQuery, ulong>
    {

    }
}
