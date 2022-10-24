using Microsoft.EntityFrameworkCore;

namespace Resty.Data.ModelConfigurations.UserBlog
{
    internal static class BlogUserBookmarkConfiguration
    {
        internal static void ConfigureBlogUserBookmark(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Blog.BlogUserBookmark>()
                .HasIndex(x => new { x.UserId, x.BlogId })
                .IsUnique();

            modelBuilder.Entity<Models.Blog.BlogUserBookmark>()
                .HasOne(x => x.User)
                .WithMany(x => x.BlogBookmarks)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Blog.BlogUserBookmark>()
                .HasOne(x => x.Blog)
                .WithMany(x => x.UserBookmarks)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
