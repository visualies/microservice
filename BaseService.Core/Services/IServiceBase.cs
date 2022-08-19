using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Core.Services
{
    public interface IServiceBase<TEntity, TRequest, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAsync(TRequest parameters);
        Task<TEntity> GetAsync(TKey key);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey key);
    }
}
