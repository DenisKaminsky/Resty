using Mapster;
using Microsoft.EntityFrameworkCore;
using Resty.Core.Interfaces.Enums.Request;
using Resty.Core.Interfaces.Types.Request;
using Resty.Data.DTO.Request;
using Resty.Data.DTO.UserBlog;
using Resty.Data.Extensions;
using Resty.Data.Interfaces.DTO.UserBlog;
using Resty.Data.Interfaces.Repositories.UserBlog;

namespace Resty.Data.Repositories.UserBlog
{
    public class CommentQueryRepository : BaseRepository, ICommentQueryRepository
    {
        public CommentQueryRepository(RestyDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IDataBlogUserComment[]> GetAllBlogCommentsAsync(int blogId)
        {
            return GetBlogCommentsQueryable()
                .Where(x => x.BlogId == blogId)
                .ToArrayAsync<IDataBlogUserComment>();
        }

        public Task<IDataBlogUserComment[]> GetPagedBlogCommentsAsync(IPagedAndFilteredAndSortedRequest request, int blogId)
        {
            return GetBlogCommentsQueryable()
                .Where(x => x.BlogId == blogId)
                .ApplySorting(request, new DataSort(nameof(IDataBlogUserComment.CreatedDateUtc), SortDirection.Descending))
                .ApplyFiltering(request)
                .ApplyPaging(request)
                .ToArrayAsync<IDataBlogUserComment>();
        }

        public Task<IDataUserBlogComment[]> GetAllUserCommentsAsync(int userId)
        {
            return GetUserCommentsQueryable()
                .Where(x => x.AuthorId == userId)
                .ToArrayAsync<IDataUserBlogComment>();
        }

        public Task<IDataUserBlogComment[]> GetPagedUserCommentsAsync(IPagedAndFilteredAndSortedRequest request, int userId)
        {
            return GetUserCommentsQueryable()
                .Where(x => x.AuthorId == userId)
                .ApplySorting(request, new DataSort(nameof(IDataUserBlogComment.CreatedDateUtc), SortDirection.Descending))
                .ApplyFiltering(request)
                .ApplyPaging(request)
                .ToArrayAsync<IDataUserBlogComment>();
        }

        #region private methods
        private IQueryable<DataBlogUserComment> GetBlogCommentsQueryable()
        {
            return DbContext.BlogUserComments
                .Include(x => x.User)
                .ProjectToType<DataBlogUserComment>();
        }

        private IQueryable<DataUserBlogComment> GetUserCommentsQueryable()
        {
            return DbContext.BlogUserComments
                .Include(x => x.Blog)
                .ProjectToType<DataUserBlogComment>();
        }
        #endregion
    }
}
