using Microsoft.EntityFrameworkCore;
using Resty.Core.Interfaces.Constraints.Blog;

namespace Resty.Data.ModelConfigurations.Blog
{
    internal static class TagConfiguration
    {
        internal static void ConfigureTag(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Blog.Tag>()
                .HasIndex(x => x.Title)
                .IsUnique();

            modelBuilder.Entity<Models.Blog.Tag>()
                .Property(x => x.Title)
                .HasMaxLength(TagConstraints.TitleMaxLength)
                .IsRequired();
        }
    }
}
