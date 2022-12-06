using Resty.Business.Interfaces.DTO.User;
using Resty.Core.Interfaces.Enums.Blog;

namespace Resty.Business.Interfaces.DTO.Blog
{
    public interface IBlogBase: IBaseUnit
    {
        string Title { get; }

        DateTime CreatedDateUtc { get; }

        IAuthor Author { get; }

        BlogTypes Type { get; }

        int Rating { get; }

        int NumberOfViews { get; }

        int NumberOfBookmarks { get; }

        int NumberOfComments { get; }
    }
}
