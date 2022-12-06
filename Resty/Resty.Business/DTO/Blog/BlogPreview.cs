using Resty.Business.Interfaces.DTO.Blog;

namespace Resty.Business.DTO.Blog
{
    public class BlogPreview : BlogBase, IBlogPreview
    {
        public string Preview { get; set; }
    }
}
