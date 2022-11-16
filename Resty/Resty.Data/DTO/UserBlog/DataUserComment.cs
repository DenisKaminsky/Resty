using Resty.Data.Interfaces.DTO.Blog;
using Resty.Data.Interfaces.DTO.UserBlog;

namespace Resty.Data.DTO.UserBlog
{
    public class DataUserComment : DataBaseModel, IDataUserComment
    {
        public string CommentText { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public int UserId { get; set; }

        public IDataBaseBlogInfo Blog { get; set; }
    }
}
