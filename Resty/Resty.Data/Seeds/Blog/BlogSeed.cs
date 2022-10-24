using Microsoft.EntityFrameworkCore;

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
                    AuthorId = 1
                },

                new Models.Blog.Blog
                {
                    Id = 2,
                    Title = "DenisGuest Blog",
                    Description = "Blog created by DenisGuest",
                    Content = "TEST 2",
                    CreatedDateUtc = DateTime.UtcNow.AddHours(-1),
                    AuthorId = 2
                },

                new Models.Blog.Blog
                {
                    Id = 3,
                    Title = "DenisPrime Blog",
                    Content = "TEST 3",
                    CreatedDateUtc = DateTime.UtcNow.AddHours(-2),
                    AuthorId = 3
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
