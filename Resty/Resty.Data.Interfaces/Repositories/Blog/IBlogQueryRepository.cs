using Resty.Core.Interfaces.Types.Request;
using Resty.Data.Interfaces.DTO.Blog;

namespace Resty.Data.Interfaces.Repositories.Blog
{
    public interface IBlogQueryRepository
    {
        Task<IDataBlogPreview[]> GetAllPreviewsAsync();

        Task<IDataBlogPreview[]> GetPreviewsPagedAsync(IPagedAndFilteredAndSortedRequest request);

        Task<IDataBlogPreview> GetPreviewByIdAsync(int id);

        Task<IDataBlog[]> GetAllAsync();

        Task<IDataBlog[]> GetPagedAsync(IPagedAndFilteredAndSortedRequest request);

        Task<IDataBlog> GetByIdAsync(int id);
    }
}
