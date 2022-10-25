namespace Resty.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected RestyDbContext DbContext { get; set; }

        protected BaseRepository(RestyDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
