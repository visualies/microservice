using System;
using System.Collections.Generic;
using System.Text;

namespace BaseService.Core.Repositories
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        IEnumerable<TEntity> All();

        TEntity Find(TKey key);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TKey key);
    }
}
