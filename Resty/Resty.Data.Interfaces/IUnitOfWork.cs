namespace Resty.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();

        Task RollbackAsync();

        Task CommitAsync();
    }
}
