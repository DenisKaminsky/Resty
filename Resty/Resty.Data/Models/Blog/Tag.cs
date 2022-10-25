using Resty.Data.Models.Base;

namespace Resty.Data.Models.Blog
{
    public class Tag : BaseModel
    {
        public string Title { get; set; }

        public IEnumerable<Blog> Blogs { get; set; }
    }
}
