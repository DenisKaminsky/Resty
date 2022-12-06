using Mapster;
using Microsoft.EntityFrameworkCore;
using Resty.Core.Interfaces.Enums.Request;
using Resty.Core.Interfaces.Types.Request;
using Resty.Data.DTO.Blog;
using Resty.Data.DTO.Request;
using Resty.Data.Extensions;
using Resty.Data.Interfaces.DTO.Blog;
using Resty.Data.Interfaces.Repositories.Blog;

namespace Resty.Data.Repositories.Blog
{
    public class BlogQueryRepository : BaseRepository, IBlogQueryRepository
    {
        public BlogQueryRepository(RestyDbContext context) : base(context) { }

        public Task<IDataBlogPreview[]> GetAllPreviewsAsync()
        {
            return GetPreviewsQueryable()
                .ToArrayAsync<IDataBlogPreview>();
        }

        public Task<IDataBlogPreview[]> GetPreviewsPagedAsync(IPagedAndFilteredAndSortedRequest request)
        {
            return GetPreviewsQueryable()
                .ApplySorting(request, new DataSort(nameof(IDataBlogPreview.CreatedDateUtc), SortDirection.Descending))
                .ApplyFiltering(request)
                .ApplyPaging(request)
                .ToArrayAsync<IDataBlogPreview>();
        }

        public Task<IDataBlogPreview> GetPreviewByIdAsync(int id)
        {
            return GetPreviewsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync<IDataBlogPreview>();
        }

        public Task<IDataBlog[]> GetAllAsync()
        {
            return GetBlogsQueryable()
                .ToArrayAsync<IDataBlog>();
        }

        public Task<IDataBlog[]> GetPagedAsync(IPagedAndFilteredAndSortedRequest request)
        {
            return GetBlogsQueryable()
                .ApplySorting(request, new DataSort(nameof(IDataBlog.CreatedDateUtc), SortDirection.Descending))
                .ApplyFiltering(request)
                .ApplyPaging(request)
                .ToArrayAsync<IDataBlog>();
        }

        public Task<IDataBlog> GetByIdAsync(int id)
        {
            return GetBlogsQueryable()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync<IDataBlog>();
        }

        #region private methods
        private IQueryable<DataBlog> GetBlogsQueryable()
        {
            return DbContext.Blogs
                .Include(x => x.Author)
                .Include(x => x.UserBookmarks)
                .Include(x => x.UserReviews)
                .Include(x => x.UserComments)
                .ProjectToType<DataBlog>();
        }

        private IQueryable<DataBlogPreview> GetPreviewsQueryable()
        {
            return DbContext.Blogs
                .Include(x => x.Author)
                .Include(x => x.UserBookmarks)
                .Include(x => x.UserReviews)
                .Include(x => x.UserComments)
                .ProjectToType<DataBlogPreview>();
        }
        #endregion
    }
}
