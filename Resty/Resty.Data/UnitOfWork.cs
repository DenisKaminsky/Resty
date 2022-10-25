using Microsoft.EntityFrameworkCore.Storage;
using Resty.Data.Interfaces;

namespace Resty.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RestyDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(RestyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public Task RollbackAsync()
        {
            return _transaction.RollbackAsync();
        }

        public async Task CommitAsync()
        {
            if (_dbContext != null)
            {
                await _dbContext.SaveChangesAsync();
            }

            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _dbContext?.Dispose();
        }
    }
}
