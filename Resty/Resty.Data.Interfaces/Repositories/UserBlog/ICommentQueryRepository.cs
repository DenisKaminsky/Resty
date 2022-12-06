using Resty.Core.Interfaces.Types.Request;
using Resty.Data.Interfaces.DTO.UserBlog;

namespace Resty.Data.Interfaces.Repositories.UserBlog
{
    public interface ICommentQueryRepository
    {
        Task<IDataBlogUserComment[]> GetAllBlogCommentsAsync(int blogId);

        Task<IDataBlogUserComment[]> GetPagedBlogCommentsAsync(IPagedAndFilteredAndSortedRequest request, int blogId);

        Task<IDataUserBlogComment[]> GetAllUserCommentsAsync(int userId);

        Task<IDataUserBlogComment[]> GetPagedUserCommentsAsync(IPagedAndFilteredAndSortedRequest request, int userId);
    }
}
