using Resty.Data.Interfaces.DTO.User;
using Resty.Data.Interfaces.DTO.UserBlog;

namespace Resty.Data.DTO.UserBlog
{
    public class DataBlogUserComment : DataBaseModel, IDataBlogUserComment
    {
        public int BlogId { get; set; }

        public string CommentText { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public IDataAuthor Author { get; set; }
    }
}
