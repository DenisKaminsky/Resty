using Resty.Data.Interfaces.DTO.Blog;

namespace Resty.Data.Interfaces.DTO.UserBlog
{
    public interface IDataBlogUserComment : IDataUserComment
    {
        IDataBaseBlogInfo Blog { get; }
    }
}
