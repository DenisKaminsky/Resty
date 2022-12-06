using Resty.Business.Interfaces.DTO.Blog;

namespace Resty.Business.Interfaces.DTO.UserBlog
{
    public interface IUserBlogBookmark: IBaseUnit
    {
        int UserId { get; }

        IBlogBase Blog { get; }
    }
}
