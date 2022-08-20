using BaseService.Core.Entities.DomainEntity;
using BaseService.Core.Entities.RequestEntity;
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

        public async Task<IEnumerable<Example>> FindAsync(ExampleRequest parameters)
        {
            return await QueryFilteredAsync<Example>("example_table", parameters);
        }

        public async Task<IEnumerable<Example>> GetAllAsync()
        {
            const string sql = "SELECT * FROM example_table";

            return await QueryAsync<Example>(sql);
        }

        public async Task<Example> GetAsync(ulong key)
        {
            const string sql = "SELECT * FROM example_table WHERE id = @Key";
            var param = new { Key = key };

            return await QueryFirstOrDefaultAsync<Example>(sql, param);
        }

        public async Task CreateAsync(Example entity)
        {
            const string sql = @"INSERT INTO example_table (name, last_name) Values (@Name, @LastName)";

            await ExecuteAsync(sql, entity);
        }

        public async Task UpdateAsync(Example entity)
        {
            const string sql = @"UPDATE example_table SET name = @name, last_name = @LastName WHERE id = @Id";

            await ExecuteAsync(sql, entity);
        }

        public async Task DeleteAsync(ulong key)
        {
            const string sql = "DELETE FROM example_table WHERE id = @Key";
            var param = new { Key = key };

            await ExecuteAsync(sql, param);
        }

        public void EnsureCreated()
        {
            const string sql = @"CREATE TABLE IF NOT EXISTS example_table (
                                    id              varchar(50) NOT NULL,
                                    name            varchar(50) NOT NULL,
                                    last_name       varchar(50) NOT NULL,
                                    CONSTRAINT PK__example_table PRIMARY KEY (id)
                                    );";
               
            Execute(sql);
        }
    }
}
