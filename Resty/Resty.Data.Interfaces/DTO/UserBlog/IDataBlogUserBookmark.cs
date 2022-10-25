using Resty.Data.Interfaces.DTO.Blog;
using Resty.Data.Interfaces.DTO.User;

namespace Resty.Data.Interfaces.DTO.UserBlog
{
    public interface IDataBlogUserBookmark : IDataBaseModel
    {
        IDataBaseBlogInfo Blog { get; }

        IDataAuthor User { get; }
    }
}
