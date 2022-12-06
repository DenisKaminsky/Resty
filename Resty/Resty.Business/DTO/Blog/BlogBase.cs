using Resty.Business.Interfaces.DTO.Blog;
using Resty.Business.Interfaces.DTO.User;
using Resty.Core.Interfaces.Enums.Blog;

namespace Resty.Business.DTO.Blog
{
    public class BlogBase : BaseUnit, IBlogBase
    {
        public string Title { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public IAuthor Author { get; set; }

        public BlogTypes Type { get; set; }

        public int Rating { get; set; }

        public int NumberOfViews { get; set; }

        public int NumberOfBookmarks { get; set; }

        public int NumberOfComments { get; set; }
    }
}
