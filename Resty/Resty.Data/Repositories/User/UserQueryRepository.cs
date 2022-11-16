using Mapster;
using Microsoft.EntityFrameworkCore;
using Resty.Core.Interfaces.Enums.Request;
using Resty.Core.Interfaces.Types.Request;
using Resty.Data.DTO.Request;
using Resty.Data.DTO.User;
using Resty.Data.Extensions;
using Resty.Data.Interfaces.DTO.User;
using Resty.Data.Interfaces.Repositories.User;

namespace Resty.Data.Repositories.User
{
    public class UserQueryRepository : BaseRepository, IUserQueryRepository
    {
        public UserQueryRepository(RestyDbContext context) : base(context) { }

        public Task<IDataUser[]> GetAllAsync()
        {
            return GetUsersQueryable()
                .ToArrayAsync<IDataUser>();
        }

        public Task<IDataUser> GetByIdAsync(int id)
        {
            return GetUsersQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync<IDataUser>();
        }

        public Task<IDataUser[]> GetPagedAsync(IPagedAndFilteredAndSortedRequest request)
        {
            return GetUsersQueryable()
                .ApplySorting(request, new DataSort(nameof(DataUser.Username), SortDirection.Ascending))
                .ApplyFiltering(request)
                .ApplyPaging(request)
                .ToArrayAsync<IDataUser>();
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

        private IQueryable<DataUser> GetUsersQueryable()
        {
            return DbContext.Users
                .ProjectToType<DataUser>();
        }
    }
}
