using Resty.Data.Models.Base;

namespace Resty.Data.Models.Blog
{
    public class BlogUserBookmark : BaseModel
    {
        public int UserId { get; set; }

        public User.User User { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
