using Mapster;
using Microsoft.EntityFrameworkCore;
using Resty.Core.Interfaces.Enums.Request;
using Resty.Core.Interfaces.Types.Request;
using Resty.Data.DTO.Request;
using Resty.Data.DTO.UserBlog;
using Resty.Data.Extensions;
using Resty.Data.Interfaces.DTO.UserBlog;
using Resty.Data.Interfaces.Repositories.UserBlog;

namespace Resty.Data.Repositories.Blog
{
    public class BlogCommentQueryRepository : BaseRepository, IBlogCommentQueryRepository
    {
        public BlogCommentQueryRepository(RestyDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IDataBlogUserComment[]> GetAllAsync(int blogId)
        {
            return GetBlogCommentsQueryable()
                .Where(x => x.BlogId == blogId)
                .ToArrayAsync<IDataBlogUserComment>();
        }

        public Task<IDataBlogUserComment[]> GetPagedAsync(IPagedAndFilteredAndSortedRequest request, int blogId)
        {
            return GetBlogCommentsQueryable()
                .Where(x => x.BlogId == blogId)
                .ApplySorting(request, new DataSort(nameof(IDataBlogUserComment.CreatedDateUtc), SortDirection.Descending))
                .ApplyFiltering(request)
                .ApplyPaging(request)
                .ToArrayAsync<IDataBlogUserComment>();
        }

        #region private methods
        private IQueryable<DataBlogUserComment> GetBlogCommentsQueryable()
        {
            return DbContext.BlogUserComments
                .Include(x => x.User)
                .ProjectToType<DataBlogUserComment>();
        }
        #endregion
    }
}
