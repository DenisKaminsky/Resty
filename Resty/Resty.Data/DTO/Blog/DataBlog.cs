using Resty.Data.Interfaces.DTO.Blog;

namespace Resty.Data.DTO.Blog
{
    public class DataBlog : DataBaseBlogInfo, IDataBlog
    {
        public string Content { get; set; }
    }
}
