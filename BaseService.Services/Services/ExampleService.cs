using BaseService.Core;
using BaseService.Core.Entities.DataEntity;
using BaseService.Core.Entities.RequestEntity;
using BaseService.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Services.Services
{
    public class ExampleService : IExampleService
    {
        private readonly IUnitOfWork _context;

        public ExampleService(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork;
        }

        public async Task<IEnumerable<Example>> FindAsync(ExampleRequest parameters)
        {
            return await _context.ExampleRepository.FindAsync(parameters);
        }

        public async Task<Example> GetAsync(ulong key)
        {
            return await _context.ExampleRepository.GetAsync(key);
        }

        public async Task CreateAsync(Example entity)
        {
            await _context.ExampleRepository.CreateAsync(entity);
        }

        public Task DeleteAsync(ulong key)
        {
            throw new NotImplementedException();
        }


        public Task UpdateAsync(Example entity)
        {
            throw new NotImplementedException();
        }
    }
}
