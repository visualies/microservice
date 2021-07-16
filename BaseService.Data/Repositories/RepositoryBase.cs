using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BaseService.Data.Repositories
{
    internal abstract class RepositoryBase
    {
        private readonly IDbTransaction _transaction;
        private IDbConnection Connection { get { return _transaction.Connection; } }

        public RepositoryBase(IDbTransaction transaction)
        {
            this._transaction = transaction;
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param)
        {
            return await Connection.QueryFirstOrDefaultAsync<T>(sql, param, _transaction);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            return await Connection.QueryAsync<T>(sql, param, _transaction);
        }

        protected async Task ExecuteAsync(string sql, object param)
        {
            await Connection.ExecuteAsync(sql, param, _transaction);
        }
    }
}
