using Resty.Business.Interfaces.DTO.Blog;

namespace Resty.Business.DTO.Blog
{
    public class Blog : BlogBase, IBlog
    {
        public string Content { get; set; }
    }
}
