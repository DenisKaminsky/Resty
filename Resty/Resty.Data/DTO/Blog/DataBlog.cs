using Resty.Data.Interfaces.DTO.Blog;
using Resty.Data.Interfaces.DTO.UserBlog;

namespace Resty.Data.DTO.Blog
{
    public class DataBlog : DataBaseBlogInfo, IDataBlog
    {

        public string Content { get; set; }

        public int Rating { get; set; }

        public int UserGrade { get; set; }

        public bool HasUserBookmark { get; set; }

        public int NumberOfViews { get; set; }

        public int NumberOfBookmarks { get; set; }

        public IEnumerable<IDataUserComment> UserComments { get; set; }
    }
}
