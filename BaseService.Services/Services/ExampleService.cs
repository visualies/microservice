using BaseService.Core;
using BaseService.Core.Entities;
using BaseService.Core.Requests;
using BaseService.Core.Services;
using System.Collections.Generic;
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

        public async Task CreateAsync(Example entity)
        {
            await _context.ExampleRepository.CreateAsync(entity);
            _context.Commit();
        }

        public async Task<Example> GetAsync(ulong key)
        {
            return await _context.ExampleRepository.GetAsync(key);
        }

        public async Task UpdateAsync(Example entity)
        {
            await _context.ExampleRepository.UpdateAsync(entity);
            _context.Commit();
        }

        public async Task DeleteAsync(ulong key)
        {
            await _context.ExampleRepository.DeleteAsync(key);
            _context.Commit();
        }
    }
}
