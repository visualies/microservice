using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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

        protected T QuerySingleOrDefault<T>(string sql, object param)
        {
            return Connection.QuerySingleOrDefault<T>(sql, param, transaction);
        }

        protected IEnumerable<T> Query<T>(string sql, object param = null)
        {
            return Connection.Query<T>(sql, param, transaction);
        }

        protected void Execute(string sql, object param)
        {
            Connection.Execute(sql, param, transaction);
        }
    }
}
