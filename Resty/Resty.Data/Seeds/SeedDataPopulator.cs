using Microsoft.EntityFrameworkCore;
using Resty.Data.Seeds.Blog;
using Resty.Data.Seeds.User;
using Resty.Data.Seeds.UserBlog;

namespace Resty.Data.Seeds
{
    internal static class SeedDataPopulator
    {
        internal static void PopulateSeedData(this ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.SeedUserRoles();
            modelBuilder.SeedUsers();
            #endregion

            #region Blogs
            modelBuilder.SeedBlogs();
            modelBuilder.SeedBlogUserBookmarks();
            modelBuilder.SeedBlogUserComments();
            modelBuilder.SeedBlogUserReviews();
            #endregion
        }
    }
}
