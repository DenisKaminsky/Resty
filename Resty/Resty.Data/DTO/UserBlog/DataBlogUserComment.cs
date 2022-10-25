using Resty.Data.Interfaces.DTO.Blog;
using Resty.Data.Interfaces.DTO.UserBlog;

namespace Resty.Data.DTO.UserBlog
{
    public class DataBlogUserComment : DataUserComment, IDataBlogUserComment
    {
        public IDataBaseBlogInfo Blog { get; set; }
    }
}
