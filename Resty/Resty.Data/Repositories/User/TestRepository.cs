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
    public class TestRepository : BaseRepository, ITestRepository
    {
        private class PagedRequest: IPagedRequest
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }

        private class FilteredRequest : IFilteredRequest
        {
            public IEnumerable<IFilter> Filters { get; set; }
            public FilterLogic Logic { get; set; }
        }

        private class Filter : IFilter
        {
            public FilterOperator Operator { get; set; }
            public string Field { get; set; }
            public string Value { get; set; }
        }

        private class SortedRequest : ISortedRequest
        {
            public IEnumerable<ISort> Sortings { get; set; }
        }

        private class Sort: ISort
        {
            public SortDirection Direction { get; set; }
            public string Field { get; set; }
        }



        public TestRepository(RestyDbContext context) : base(context) { }

        public Task<IDataUser[]> GetAllAsync()
        {
            var a = DbContext.Users
                .ProjectToType<DataUser>()
                .ToArray();

            var b = DbContext.Users
                .ProjectToType<DataUser>()
                .ApplyPaging(new PagedRequest() { PageSize = 2, PageNumber = 2})
                .ToArray();

            var filters = new FilteredRequest
            {
                Logic = FilterLogic.And,
                Filters = new[]
                {
                    new Filter { Operator = FilterOperator.GreaterThanOrEqual, Value = "2", Field = $"{nameof(Models.Blog.Blog.Id)}"},
                    new Filter { Operator = FilterOperator.LessThanOrEqual, Value = "4", Field = $"{nameof(Models.Blog.Blog.Id)}"},
                    new Filter { Operator = FilterOperator.Contains, Value = "Denis", Field = $"{nameof(Models.Blog.Blog.Author)}.{nameof(Models.User.User.Username)}"},
                }
            };

            var c = DbContext.Blogs
                .ApplyFiltering(filters)
                .ToQueryString();

            var c2 = DbContext.Blogs
                .ApplyFiltering(filters)
                .ToArray();

            var sortings = new SortedRequest()
            {
                Sortings = new[]
                {
                    new Sort() { Direction = SortDirection.Descending, Field = $"{nameof(Models.Blog.Blog.Id)}"},
                    new Sort() { Direction = SortDirection.Ascending, Field = $"{nameof(Models.Blog.Blog.CreatedDateUtc)}"},
                    new Sort() { Direction = SortDirection.Ascending, Field = $"{nameof(Models.Blog.Blog.Author)}.{nameof(Models.User.User.Username)}"},
                }
            };

            var d = DbContext.Blogs
                .AsQueryable()
                .ApplySorting(sortings, new DataSort(nameof(Models.Blog.Blog.Id), SortDirection.Ascending))
                .ToQueryString();

            var d2 = DbContext.Blogs
                .AsQueryable()
                .OrderBy(x => x.Author.Username)
                .ApplySorting(sortings, new DataSort(nameof(Models.Blog.Blog.Id), SortDirection.Ascending))
                .ToArray();


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
