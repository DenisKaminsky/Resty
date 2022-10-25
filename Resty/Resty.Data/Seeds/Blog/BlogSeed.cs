using Microsoft.EntityFrameworkCore;
using Resty.Core.Interfaces.Enums.Blog;

namespace Resty.Data.Seeds.Blog
{
    internal static class BlogSeed
    {
        public static void SeedBlogs(this ModelBuilder modelBuilder)
        {
            var blogs = new[]
            {
                new Models.Blog.Blog
                {
                    Id = 1,
                    Title = "DenisAdmin Blog",
                    Description = "Blog created by DenisAdmin",
                    Content = "TEST",
                    CreatedDateUtc = DateTime.UtcNow,
                    Type = BlogTypes.Post,
                    AuthorId = 1
                },

                new Models.Blog.Blog
                {
                    Id = 2,
                    Title = "DenisGuest Blog",
                    Description = "Blog created by DenisGuest",
                    Content = "TEST 2",
                    CreatedDateUtc = DateTime.UtcNow.AddHours(-1),
                    Type = BlogTypes.Post,
                    AuthorId = 2
                },

                new Models.Blog.Blog
                {
                    Id = 3,
                    Title = "DenisPrime Blog",
                    Content = "TEST 3",
                    CreatedDateUtc = DateTime.UtcNow.AddHours(-2),
                    Type = BlogTypes.Post,
                    AuthorId = 3
                },

                new Models.Blog.Blog
                {
                    Id = 4,
                    Title = "DenisAdmin News 1",
                    Content = "TEST NEWS 1",
                    CreatedDateUtc = DateTime.UtcNow.AddHours(-2),
                    Type = BlogTypes.News,
                    AuthorId = 1
                },

                new Models.Blog.Blog
                {
                    Id = 5,
                    Title = "DenisAdmin News 3",
                    Content = "TEST NEWS 2",
                    CreatedDateUtc = DateTime.UtcNow.AddHours(-3),
                    Type = BlogTypes.News,
                    AuthorId = 1
                },

                new Models.Blog.Blog
                {
                    Id = 6,
                    Title = "DenisAdmin News 3",
                    Content = "TEST NEWS 3",
                    CreatedDateUtc = DateTime.UtcNow.AddHours(-4),
                    Type = BlogTypes.News,
                    AuthorId = 1
                }
            };

            modelBuilder.Entity<Models.Blog.Blog>().HasData(blogs);

            modelBuilder.HasSequence<int>("Blogs_Seq", schema: "public")
                .StartsAt(blogs.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Models.Blog.Blog>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"Blogs_Seq\"')");
        }
    }
}
