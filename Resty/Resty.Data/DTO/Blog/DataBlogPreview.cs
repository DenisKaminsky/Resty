using Resty.Data.Interfaces.DTO.Blog;

namespace Resty.Data.DTO.Blog
{
    public class DataBlogPreview : DataBaseBlogInfo, IDataBlogPreview
    {
        public string Preview { get; set; }

        public int NumberOfComments { get; set; }
    }
}
