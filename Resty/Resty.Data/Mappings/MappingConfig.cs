using Mapster;
using Resty.Data.DTO.Blog;
using Resty.Data.DTO.UserBlog;

namespace Resty.Data.Mappings
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            #region Blog

            config.NewConfig<Models.Blog.Blog, DataBlog>()
                .Map(dest => dest.NumberOfComments, src => src.UserComments.Count())
                .Map(dest => dest.NumberOfBookmarks, src => src.UserBookmarks.Count())
                .Map(dest => dest.NumberOfViews, src => src.UserReviews.Count())
                .Map(dest => dest.Rating, src => src.UserReviews.Sum(x => x.Grade));

            config.NewConfig<Models.Blog.Blog, DataBlogPreview>()
                .Map(dest => dest.NumberOfComments, src => src.UserComments.Count())
                .Map(dest => dest.NumberOfBookmarks, src => src.UserBookmarks.Count())
                .Map(dest => dest.NumberOfViews, src => src.UserReviews.Count())
                .Map(dest => dest.Rating, src => src.UserReviews.Sum(x => x.Grade));
            #endregion

            #region Blog Comments
            config.NewConfig<Models.Blog.BlogUserComment, DataBlogUserComment>()
                .Map(dest => dest.Author, src => src.User);
            config.NewConfig<Models.Blog.BlogUserComment, DataUserBlogComment>()
                .Map(dest => dest.AuthorId, src => src.UserId);
            #endregion
        }
    }
}
