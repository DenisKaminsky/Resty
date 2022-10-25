using Resty.Data.Interfaces.DTO.Blog;

namespace Resty.Data.DTO.Blog
{
    public class DataBlogPreview : DataBaseBlogInfo, IDataBlogPreview
    {

        public string Description { get; set; }

        public int Rating { get; set; }

        public int NumberOfComments { get; set; }

        public int NumberOfBookmarks { get; set; }

        public int NumberOfViews { get; set; }
    }
}
