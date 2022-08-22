using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseService.Core.Repositories
{
    public interface IRepositoryBase<TEntity, TRequest, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAsync(TRequest parameters);

        Task<TEntity> GetAsync(TKey key);

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TKey key);

        void EnsureCreated();
    }
}
