using Mapster;
using Microsoft.EntityFrameworkCore;
using Resty.Core.Interfaces.Enums.Request;
using Resty.Core.Interfaces.Types.Request;
using Resty.Core.Interfaces.Types.Request.Default;
using Resty.Data.DTO.Blog;
using Resty.Data.DTO.Request;
using Resty.Data.DTO.User;
using Resty.Data.DTO.UserBlog;
using Resty.Data.Extensions;
using Resty.Data.Interfaces.DTO.User;
using Resty.Data.Interfaces.Repositories.Blog;
using Resty.Data.Interfaces.Repositories.User;
using Resty.Data.Interfaces.Repositories.UserBlog;

namespace Resty.Data.Repositories.User
{
    public class TestRepository : BaseRepository, ITestRepository
    {

        public class PagedRequest: IPagedRequest
        {
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
        }

        public class FilteredRequest : IFilteredRequest
        {
            public IEnumerable<IFilter> Filters { get; set; }
            public FilterLogic Logic { get; set; }
        }

        public class Filter : IFilter
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


        private readonly IBlogQueryRepository _blogQueryRepository;
        private readonly IBlogCommentQueryRepository _blogCommentQueryRepository;

        public TestRepository(RestyDbContext context, IBlogQueryRepository blogQueryRepository, IBlogCommentQueryRepository blogCommentQueryRepository) : base(context)
        {
            _blogQueryRepository = blogQueryRepository;
            _blogCommentQueryRepository = blogCommentQueryRepository;
        }

        public async Task<IDataUser[]> Test1()
        {
            try
            {
                //var req = new DataPagedAndFilteredAndSortedRequest(1, 3);
                //req.AddFilter(new Filter()
                //    { Field = nameof(DataBlog.Title), Operator = FilterOperator.Contains, Value = "den" });
                //var res1 = await _blogQueryRepository.GetAllPreviewsAsync();
                //var res2 = await _blogQueryRepository.GetPreviewsPagedAsync(req);
                //var res3 = await _blogQueryRepository.GetPreviewByIdAsync(1);
                //var res4 = await _blogQueryRepository.GetAllAsync();
                //var res5 = await _blogQueryRepository.GetPagedAsync(req);
                //var res6 = await _blogQueryRepository.GetByIdAsync(1);

                var req2 = new DataPagedAndFilteredAndSortedRequest(1, 5);
                req2.AddFilter(new Filter()
                    { Field = nameof(DataBlogUserComment.CommentText), Operator = FilterOperator.Contains, Value = "Denis" });
                var res21 = await _blogCommentQueryRepository.GetAllAsync(1);
                var res22 = await _blogCommentQueryRepository.GetPagedAsync(req2, 1);


            }
            catch (Exception ex)
            {
                var b = 1;
            }


            return await DbContext.Users
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
