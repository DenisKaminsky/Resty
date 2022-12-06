using Resty.Business.Interfaces.DTO.User;

namespace Resty.Business.Interfaces.DTO.UserBlog
{
    public interface IBlogUserComment: IBaseUnit
    {
        int BlogId { get; }

        string CommentText { get; }

        DateTime CreatedDateUtc { get; }

        IAuthor Author { get; }
    }
}
