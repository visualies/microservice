using BaseService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseService.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IExampleRepository ExampleRepository { get; }
        void Commit();
    }
}
