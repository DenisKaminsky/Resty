using Resty.Data.Interfaces.DTO.Blog;

namespace Resty.Data.Interfaces.DTO.UserBlog
{
    public interface IDataUserBlogBookmark : IDataBaseModel
    {
        int UserId { get; }

        IDataBaseBlogInfo Blog { get; }
    }
}
