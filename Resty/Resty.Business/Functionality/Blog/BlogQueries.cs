using Mapster;
using Resty.Business.DTO.Blog;
using Resty.Business.Interfaces.DTO.Blog;
using Resty.Business.Interfaces.Functionality.Blog;
using Resty.Core.Interfaces.Types.Request;
using Resty.Data.Interfaces.Repositories.Blog;

namespace Resty.Business.Functionality.Blog
{
    public class BlogQueries: BaseQueries, IBlogQueries
    {
        private readonly IBlogQueryRepository _blogQueryRepository;

        public BlogQueries(IBlogQueryRepository blogQueryRepository)
        {
            _blogQueryRepository = blogQueryRepository;
        }

        public async Task<IEnumerable<IBlogPreview>> GetAllPreviewsAsync()
        {
            var items = await _blogQueryRepository.GetAllPreviewsAsync();

            return items.Adapt<IEnumerable<BlogPreview>>();
        }

        public async Task<IEnumerable<IBlogPreview>> GetPreviewsPagedAsync(IPagedAndFilteredAndSortedRequest request)
        {
            var items = await _blogQueryRepository.GetPreviewsPagedAsync(request);

            return items.Adapt<IEnumerable<BlogPreview>>();
        }

        public async Task<IBlogPreview> GetPreviewByIdAsync(int id)
        {
            var item = await _blogQueryRepository.GetPreviewByIdAsync(id);

            return item.Adapt<BlogPreview>();
        }

        public async Task<IEnumerable<IBlog>> GetAllAsync()
        {
            var items = await _blogQueryRepository.GetAllAsync();

            return items.Adapt<IEnumerable<DTO.Blog.Blog>>();
        }

        public async Task<IEnumerable<IBlog>> GetPagedAsync(IPagedAndFilteredAndSortedRequest request)
        {
            var items = await _blogQueryRepository.GetPagedAsync(request);

            return items.Adapt<IEnumerable<DTO.Blog.Blog>>();
        }

        public async Task<IBlog> GetByIdAsync(int id)
        {
            var item = await _blogQueryRepository.GetByIdAsync(id);

            return item.Adapt<DTO.Blog.Blog>();
        }
    }
}
