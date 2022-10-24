using Microsoft.EntityFrameworkCore;
using Resty.Core.Constraints.Blog;

namespace Resty.Data.ModelConfigurations.UserBlog
{
    internal static class BlogUserCommentConfiguration
    {
        internal static void ConfigureBlogUserComment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Blog.BlogUserComment>()
                .HasIndex(x => new { x.UserId, x.BlogId })
                .IsUnique();

            modelBuilder.Entity<Models.Blog.BlogUserComment>()
                .Property(x => x.CommentText)
                .HasMaxLength(BlogUserCommentConstraints.CommentMaxLength)
                .IsRequired();

            modelBuilder.Entity<Models.Blog.BlogUserComment>()
                .HasOne(x => x.User)
                .WithMany(x => x.BlogComments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Blog.BlogUserComment>()
                .HasOne(x => x.Blog)
                .WithMany(x => x.UserComments)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
