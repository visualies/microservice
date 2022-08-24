using BaseService.Core.Entities;
using BaseService.Core.Requests;

namespace BaseService.Core.Services
{
    public interface IExampleService : IServiceBase<Example, ExampleRequest, ulong>
    {

    }
}
