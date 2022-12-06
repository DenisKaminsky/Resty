using Resty.Data.Interfaces.DTO.Blog;
using Resty.Data.Interfaces.DTO.UserBlog;

namespace Resty.Data.DTO.UserBlog
{
    public class DataUserBlogComment : DataBaseModel, IDataUserBlogComment
    {
        public string CommentText { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public int AuthorId { get; set; }

        public IDataBaseBlogInfo Blog { get; set; }
    }
}
