using Resty.Data.Interfaces.DTO.User;

namespace Resty.Data.Interfaces.DTO.UserBlog
{
    public interface IDataUserComment : IDataBaseModel
    {
        string CommentText { get; }

        DateTime CreatedDateUtc { get; }

        IDataAuthor Author { get; }
    }
}
