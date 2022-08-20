using BaseService.Core.Entities.DomainEntity;
using BaseService.Core.Entities.RequestEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseService.Core.Services
{
    public interface IExampleService : IServiceBase<Example, ExampleRequest, ulong>
    {

    }
}
