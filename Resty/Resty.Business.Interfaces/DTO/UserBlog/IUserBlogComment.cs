using Resty.Business.Interfaces.DTO.Blog;

namespace Resty.Business.Interfaces.DTO.UserBlog
{
    public interface IUserBlogComment: IBaseUnit
    {
        string CommentText { get; }

        DateTime CreatedDateUtc { get; }

        int AuthorId { get; }

        IBlogBase Blog { get; }
    }
}
