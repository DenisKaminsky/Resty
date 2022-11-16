using Resty.Data.Interfaces.DTO.User;

namespace Resty.Data.Interfaces.DTO.UserBlog
{
    public interface IDataBlogUserComment : IDataBaseModel
    {
        int BlogId { get; }

        string CommentText { get; }

        DateTime CreatedDateUtc { get; }

        IDataAuthor Author { get; }
    }
}
