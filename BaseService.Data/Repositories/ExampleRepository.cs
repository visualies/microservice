using BaseService.Core.Entities;
using BaseService.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BaseService.Data.Repositories
{
    internal class ExampleRepository : RepositoryBase, IExampleRepository
    {
        public ExampleRepository(IDbTransaction transaction) : base(transaction)
        {

        }

        public async Task AddAsync(Example entity)
        {
            var sql = @"INSERT INTO example_table (Name, Description) Values (@Name, @Description)";

            await ExecuteAsync(sql, entity);
        }

        public async Task<IEnumerable<Example>> GetAllAsync()
        {
            var sql = "SELECT * FROM example_table";

            return await QueryAsync<Example>(sql);
        }

        public async Task<Example> GetAsync(string key)
        {
            var sql = "SELECT * FROM example_table WHERE id = @Key";
            var param = new { Key = key };

            return await QueryFirstOrDefaultAsync<Example>(sql, param);
        }

        public async Task<Example> FindByNameAsync(string exampleName)
        {
            var sql = "SELECT * FROM example_table WHERE name = @Name";
            var param = new { Name = exampleName };

            return await QueryFirstOrDefaultAsync<Example>(sql, param);
        }

        public async Task RemoveAsync(string key)
        {
            var sql = "DELETE FROM example_table WHERE id = @Key";
            var param = new { Key = key };

            await ExecuteAsync(sql, param);
        }

        public async Task UpdateAsync(Example entity)
        {
            var sql = @"UPDATE example_table SET name = @name, description = @Description WHERE id = @Id";

            await ExecuteAsync(sql, entity);
        }
    }
}
