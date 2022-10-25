using Mapster;
using Microsoft.EntityFrameworkCore;
using Resty.Data.DTO.User;
using Resty.Data.Interfaces.DTO.User;
using Resty.Data.Interfaces.Repositories.User;

namespace Resty.Data.Repositories.User
{
    public class UserQueryRepository : BaseRepository, IUserQueryRepository
    {
        public UserQueryRepository(RestyDbContext context) : base(context) { }

        public Task<IDataUser[]> GetAllAsync()
        {
            return DbContext.Users
                .ProjectToType<DataUser>()
                .ToArrayAsync<IDataUser>();
        }

        public Task<IDataUser> GetByIdAsync(int id)
        {
            return DbContext.Users
                .ProjectToType<DataUser>()
                .FirstOrDefaultAsync<IDataUser>(x => x.Id == id);
        }

        public Task<bool> ValidateUsernameExistsAsync(string username)
        {
            return DbContext.Users
                .AnyAsync(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public Task<bool> ValidateEmailExistsAsync(string email)
        {
            return DbContext.Users
                .AnyAsync(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
