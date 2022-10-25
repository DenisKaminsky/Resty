using Resty.Core.Interfaces.Enums.Blog;
using Resty.Data.Models.Base;

namespace Resty.Data.Models.Blog
{
    public class Blog : BaseModel
    {
        public string Title { get; set; }
            
        public string Preview { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public User.User Author { get; set; }   

        public BlogTypes Type { get; set; }

        public IEnumerable<BlogUserBookmark> UserBookmarks { get; set; }

        public IEnumerable<BlogUserComment> UserComments { get; set; }

        public IEnumerable<BlogUserReview> UserReviews { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
