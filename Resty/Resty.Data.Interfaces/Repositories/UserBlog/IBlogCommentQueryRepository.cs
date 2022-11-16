using Resty.Core.Interfaces.Types.Request;
using Resty.Data.Interfaces.DTO.UserBlog;

namespace Resty.Data.Interfaces.Repositories.UserBlog
{
    public interface IBlogCommentQueryRepository
    {
        Task<IDataBlogUserComment[]> GetAllAsync(int blogId);

        Task<IDataBlogUserComment[]> GetPagedAsync(IPagedAndFilteredAndSortedRequest request, int blogId);
    }
}
