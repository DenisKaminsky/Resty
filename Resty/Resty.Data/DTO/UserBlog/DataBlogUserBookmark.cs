using Resty.Data.Interfaces.DTO.Blog;
using Resty.Data.Interfaces.DTO.User;
using Resty.Data.Interfaces.DTO.UserBlog;
using Resty.Data.Models.Base;

namespace Resty.Data.DTO.UserBlog
{
    public class DataBlogUserBookmark : BaseModel, IDataBlogUserBookmark
    {
        public IDataBaseBlogInfo Blog { get; set; }

        public IDataAuthor User { get; set; }
    }
}
