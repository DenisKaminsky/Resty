using Resty.Business.Interfaces.DTO.User;
using Resty.Business.Interfaces.DTO.UserBlog;

namespace Resty.Business.DTO.UserBlog
{
    public class BlogUserComment : BaseUnit, IBlogUserComment
    {
        public int BlogId { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public IAuthor Author { get; set; }
    }
}
