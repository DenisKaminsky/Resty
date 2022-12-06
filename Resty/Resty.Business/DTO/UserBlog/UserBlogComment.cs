using Resty.Business.Interfaces.DTO.Blog;
using Resty.Business.Interfaces.DTO.UserBlog;

namespace Resty.Business.DTO.UserBlog
{
    public class DataUserBlogComment : BaseUnit, IUserBlogComment
    {
        public string CommentText { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public int AuthorId { get; set; }

        public IBlogBase Blog { get; set; }
    }
}
