using Mapster;
using Resty.Data.DTO.Blog;
using Resty.Data.DTO.UserBlog;

namespace Resty.Data.Mappings.Blog
{
    public class BlogMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            #region Blog
            config.NewConfig<Models.Blog.Blog, DataBlog>()
                .Map(dest => dest.NumberOfBookmarks, src => src.UserBookmarks.Count())
                .Map(dest => dest.NumberOfViews, src => src.UserReviews.Count())
                .Map(dest => dest.Rating, src => src.UserReviews.Sum(x => x.Grade))
                .Map(dest => dest.Author, src => src.Author);

            config.NewConfig<Models.Blog.Blog, DataBlogPreview>()
                .Map(dest => dest.NumberOfBookmarks, src => src.UserBookmarks.Count())
                .Map(dest => dest.NumberOfViews, src => src.UserReviews.Count())
                .Map(dest => dest.Rating, src => src.UserReviews.Sum(x => x.Grade));
            #endregion

            #region Blog Comments
            config.NewConfig<Models.Blog.BlogUserComment, DataBlogUserComment>()
                .Map(dest => dest.Author, src => src.User);
            #endregion
        }
    }
}
