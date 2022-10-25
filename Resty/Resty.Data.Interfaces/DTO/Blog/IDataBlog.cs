using Resty.Data.Interfaces.DTO.UserBlog;

namespace Resty.Data.Interfaces.DTO.Blog
{
    public interface IDataBlog : IDataBaseBlogInfo
    {

        string Content { get; }

        int Rating { get; }

        int UserGrade { get; }

        bool HasUserBookmark { get; }

        int NumberOfViews { get; }

        int NumberOfBookmarks { get; }

        IEnumerable<IDataUserComment> UserComments { get; }
    }
}
