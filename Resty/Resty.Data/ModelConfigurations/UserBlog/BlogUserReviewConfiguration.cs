using Microsoft.EntityFrameworkCore;

namespace Resty.Data.ModelConfigurations.UserBlog
{
    internal static class BlogUserReviewConfiguration
    {
        internal static void ConfigureBlogUserReview(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Blog.BlogUserReview>()
                .HasIndex(x => new { x.UserId, x.BlogId })
                .IsUnique();

            modelBuilder.Entity<Models.Blog.BlogUserReview>()
                .HasOne(x => x.User)
                .WithMany(x => x.BlogReviews)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Blog.BlogUserReview>()
                .HasOne(x => x.Blog)
                .WithMany(x => x.UserReviews)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Blog.BlogUserReview>()
                .HasCheckConstraint("CK_BlogUserReview_Grade", 
                    $"\"{nameof(Models.Blog.BlogUserReview.Grade)}\" >= -1 AND \"{nameof(Models.Blog.BlogUserReview.Grade)}\" <= 1");
        }
    }
}
