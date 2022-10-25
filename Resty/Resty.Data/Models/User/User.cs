using Resty.Core.Interfaces.Enums.User;
using Resty.Data.Models.Base;
using Resty.Data.Models.Blog;

namespace Resty.Data.Models.User
{
    public class User : BaseModel
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int Rating { get; set; }

        public DateTime StartDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }

        public UserRoles Role { get; set; }

        public IEnumerable<Blog.Blog> Blogs { get; set; }

        public IEnumerable<BlogUserBookmark> BlogBookmarks { get; set; }

        public IEnumerable<BlogUserComment> BlogComments { get; set; }

        public IEnumerable<BlogUserReview> BlogReviews { get; set; }
    }
}
