using Microsoft.EntityFrameworkCore;
using Resty.Core.Interfaces.Constraints.Blog;
using Resty.Core.Interfaces.Enums.Blog;

namespace Resty.Data.ModelConfigurations.Blog
{
    internal static class BlogConfiguration
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
                .Property(x => x.Preview)
                .HasMaxLength(BlogConstraints.PreviewMaxLength)
                .IsRequired(false);

            modelBuilder.Entity<Models.Blog.Blog>()
                .Property(x => x.Content)
                .IsRequired();

            modelBuilder.Entity<Models.Blog.Blog>()
                .Property(x => x.Type)
                .IsRequired()
                .HasConversion(
                    x => x.ToString(),
                    x => (BlogTypes)Enum.Parse(typeof(BlogTypes), x, true));

            modelBuilder.Entity<Models.Blog.Blog>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Blog.Blog>()
                .HasMany(p => p.Tags)
                .WithMany(p => p.Blogs)
                .UsingEntity(j => j.ToTable("BlogTags"));
        }
    }
}
