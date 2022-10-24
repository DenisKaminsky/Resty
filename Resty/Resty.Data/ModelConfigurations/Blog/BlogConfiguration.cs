using Microsoft.EntityFrameworkCore;
using Resty.Core.Constraints.Blog;

namespace Resty.Data.ModelConfigurations.Blog
{
    internal static class BlogUserBookmarkConfiguration
    {
        internal static void ConfigureBlog(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Blog.Blog>()
                .HasIndex(x => x.CreatedDateUtc);

            modelBuilder.Entity<Models.Blog.Blog>()
                .Property(x => x.Title)
                .HasMaxLength(BlogConstraints.TitleMaxLength)
                .IsRequired();

            modelBuilder.Entity<Models.Blog.Blog>()
                .Property(x => x.Description)
                .HasMaxLength(BlogConstraints.DescriptionMaxLength)
                .IsRequired(false);

            modelBuilder.Entity<Models.Blog.Blog>()
                .Property(x => x.Content)
                .IsRequired();

            modelBuilder.Entity<Models.Blog.Blog>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
