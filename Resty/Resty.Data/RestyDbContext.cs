using Microsoft.EntityFrameworkCore;
using Resty.Data.ModelConfigurations;
using Resty.Data.Models.Blog;
using Resty.Data.Models.User;
using Resty.Data.Seeds;

namespace Resty.Data
{
    public class RestyDbContext : DbContext
    {
        #region User
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

        #region Blog
        public DbSet<Blog> Blogs { get; set; }
        #endregion

        #region UserBlog (relations)
        public DbSet<BlogUserBookmark> BlogUserBookmarks { get; set; }
        public DbSet<BlogUserComment> BlogUserComments { get; set; }
        public DbSet<BlogUserReview> BlogUserReviews { get; set; }
        #endregion

        public RestyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureModels();
            modelBuilder.PopulateSeedData();
        }
    }
}
