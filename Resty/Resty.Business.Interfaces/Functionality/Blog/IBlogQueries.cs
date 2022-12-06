using Resty.Business.Interfaces.DTO.Blog;
using Resty.Core.Interfaces.Types.Request;

namespace Resty.Business.Interfaces.Functionality.Blog
{
    public interface IBlogQueries
    {
        Task<IEnumerable<IBlogPreview>> GetAllPreviewsAsync();

        Task<IEnumerable<IBlogPreview>> GetPreviewsPagedAsync(IPagedAndFilteredAndSortedRequest request);

        Task<IBlogPreview> GetPreviewByIdAsync(int id);

        Task<IEnumerable<IBlog>> GetAllAsync();

        Task<IEnumerable<IBlog>> GetPagedAsync(IPagedAndFilteredAndSortedRequest request);

        Task<IBlog> GetByIdAsync(int id);
    }
}
