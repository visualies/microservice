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
        private readonly IDbTransaction transaction;
        private IDbConnection Connection { get { return transaction.Connection; } }

        public RepositoryBase(IDbTransaction transaction)
        {
            this.transaction = transaction;
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param)
        {
            return await Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            return await Connection.QueryAsync<T>(sql, param, transaction);
        }

        protected async Task ExecuteAsync(string sql, object param)
        {
            await Connection.ExecuteAsync(sql, param, transaction);
        }
    }
}
