using BaseService.Core.Entities;
using BaseService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BaseService.Data.Repositories
{
    internal class ExampleRepository : RepositoryBase, IExampleRepository
    {
        public ExampleRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        public void Add(Example entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Example> All()
        {
            var sql = "SELECT * FROM example_table";

            return Query<Example>(sql);
        }

        public Example Find(string key)
        {
            var sql = "SELECT * FROM example_table WHERE id = @Key";
            var param = new { Key = key };

            return QuerySingleOrDefault<Example>(sql, param);
        }

        public Example FindByName(string exampleName)
        {
            var sql = "SELECT * FROM example_table WHERE name = @Name";
            var param = new { Name = exampleName };

            return QuerySingleOrDefault<Example>(sql, param);
        }

        public void Remove(string key)
        {
            var sql = "DELETE FROM example_table WHERE id = @Key";
            var param = new { Key = key };

            Execute(sql, param);
        }

        public void Update(Example entity)
        {
            var sql = @"UPDATE example_table SET name = @name, description = @Description WHERE id = @Id";

            Execute(sql, entity);
        }
    }
}
