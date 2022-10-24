using Resty.Data.Models.Base;

namespace Resty.Data.Models.Blog
{
    public class Blog : BaseModel
    {
        public string Title { get; set; }
            
        public string Description { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public User.User Author { get; set; }   

        public IEnumerable<BlogUserBookmark> UserBookmarks { get; set; }

        public IEnumerable<BlogUserComment> UserComments { get; set; }

        public IEnumerable<BlogUserReview> UserReviews { get; set; }
    }
}
