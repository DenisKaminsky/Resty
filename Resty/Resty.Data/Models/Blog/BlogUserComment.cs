using Resty.Data.Models.Base;

namespace Resty.Data.Models.Blog
{
    public class BlogUserComment : BaseModel
    {
        public string CommentText { get; set; }

        public int UserId { get; set; }

        public User.User User { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
