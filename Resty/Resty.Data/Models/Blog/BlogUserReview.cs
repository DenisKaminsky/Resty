using Resty.Data.Models.Base;

namespace Resty.Data.Models.Blog
{
    public class BlogUserReview : BaseModel
    {
        public sbyte Grade { get; set; }

        public int UserId { get; set; }

        public User.User User { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
