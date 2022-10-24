using Microsoft.EntityFrameworkCore;
using Resty.Data.ModelConfigurations.Blog;
using Resty.Data.ModelConfigurations.User;
using Resty.Data.ModelConfigurations.UserBlog;

namespace Resty.Data.ModelConfigurations
{
    internal static class ModelConfigurationManager
    {
        internal static void ConfigureModels(this ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.ConfigureUser();
            modelBuilder.ConfigureUserRole();
            #endregion

            #region Blog
            modelBuilder.ConfigureBlog();
            #endregion

            #region UserBlog (relations)
            modelBuilder.ConfigureBlogUserComment();
            modelBuilder.ConfigureBlogUserBookmark();
            modelBuilder.ConfigureBlogUserReview();
            #endregion
        }
    }
}
