using Resty.Business.Interfaces.DTO.Blog;
using Resty.Business.Interfaces.DTO.UserBlog;

namespace Resty.Business.DTO.UserBlog
{
    public class DataUserBlogBookmark : BaseUnit, IUserBlogBookmark
    {
        public int UserId { get; set; }

        public IBlogBase Blog { get; set; }
    }
}
