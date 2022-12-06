using Resty.Data.Interfaces.DTO.Blog;

namespace Resty.Data.Interfaces.DTO.UserBlog
{
    public interface IDataUserBlogComment : IDataBaseModel
    {
        string CommentText { get; }

        DateTime CreatedDateUtc { get; }

        int AuthorId { get; }

        IDataBaseBlogInfo Blog { get; }
    }
}
