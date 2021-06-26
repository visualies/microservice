using BaseService.Core;
using BaseService.Core.Entities;
using BaseService.Core.Repositories;
using BaseService.Data.Repositories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BaseService.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection connection;
        private IDbTransaction transaction;
        private IExampleRepository exampleRepository;
        private bool disposed;
          
        public UnitOfWork(BaseConfig config)
        {
            connection = new NpgsqlConnection(config.Connection.GetConnectionString());
            connection.Open();
            transaction = connection.BeginTransaction();
        }

        public IExampleRepository ExampleRepository
        {
            get
            {
                return exampleRepository ?? (exampleRepository = new ExampleRepository(transaction));
            }
        }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                transaction.Dispose();
                ResetRepositories();
                transaction = connection.BeginTransaction();
            }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        #region Private Methods
        private void ResetRepositories()
        {
            exampleRepository = null;
        }

        private void dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }
                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }
                disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
        #endregion
    }
}
