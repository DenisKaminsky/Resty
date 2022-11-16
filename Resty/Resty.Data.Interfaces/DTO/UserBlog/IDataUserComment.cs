using Resty.Data.Interfaces.DTO.Blog;

namespace Resty.Data.Interfaces.DTO.UserBlog
{
    public interface IDataUserComment : IDataBaseModel
    {
        string CommentText { get; }

        DateTime CreatedDateUtc { get; }

        int UserId { get; }

        IDataBaseBlogInfo Blog { get; }
    }
}
