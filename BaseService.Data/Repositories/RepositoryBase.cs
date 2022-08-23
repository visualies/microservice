using BaseService.Core.Attributes;
using BaseService.Core.Entities;
using BaseService.Data.Helper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BaseService.Data.Repositories
{
    internal abstract class RepositoryBase
    {
        private readonly IDbTransaction _transaction;
        private IDbConnection Connection => _transaction.Connection;

        protected RepositoryBase(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        protected async Task<IEnumerable<T>> QueryFilteredAsync<T>(string table, RequestBase param)
        {
            var sql = $"SELECT * FROM {table}";
            var statements = new List<string>();

            var props = param.GetType().GetProperties().Where(a => a.GetValue(param) != null);
            props = props.Where(a => a.GetCustomAttribute<ReservedParameterAttribute>() == null);

            if (props.Any()) sql += " WHERE ";
            foreach (PropertyInfo prop in props)
            {
                statements.Add($"{prop.Name.ToSnakeCase()} = @{prop.Name}");
            }
            sql += string.Join(" AND ", statements);

            var limit = Math.Min(param.Limit ?? 25, 25);
            var offset = (param.Page ?? 0) * limit;
            sql += $" LIMIT {limit} OFFSET {offset}";   

            return await Connection.QueryAsync<T>(sql, param, _transaction);
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

        protected void Execute(string sql)
        {
            Connection.Execute(sql, _transaction);
        }
    }
}
