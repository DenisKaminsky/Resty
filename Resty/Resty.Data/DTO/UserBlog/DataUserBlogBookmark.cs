using Resty.Data.Interfaces.DTO.Blog;
using Resty.Data.Interfaces.DTO.UserBlog;

namespace Resty.Data.DTO.UserBlog
{
    public class DataUserBlogBookmark : DataBaseModel, IDataUserBlogBookmark
    {
        public int UserId { get; set; }

        public IDataBaseBlogInfo Blog { get; set; }
    }
}
