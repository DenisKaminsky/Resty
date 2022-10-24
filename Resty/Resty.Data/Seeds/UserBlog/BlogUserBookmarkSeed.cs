using Microsoft.EntityFrameworkCore;

namespace Resty.Data.Seeds.UserBlog
{
    internal static class BlogUserBookmarkSeed
    {
        public static void SeedBlogUserBookmarks(this ModelBuilder modelBuilder)
        {
            var blogUserBookmarks = new[]
            {
                new Models.Blog.BlogUserBookmark
                { 
                    Id = 1,
                    UserId = 1,
                    BlogId = 2
                },

                new Models.Blog.BlogUserBookmark
                {
                    Id = 2,
                    UserId = 2,
                    BlogId = 3
                },

                new Models.Blog.BlogUserBookmark
                {
                    Id = 3,
                    UserId = 3,
                    BlogId = 1
                }
            };

            modelBuilder.Entity<Models.Blog.BlogUserBookmark>().HasData(blogUserBookmarks);

            modelBuilder.HasSequence<int>("BlogUserBookmark_Seq", schema: "public")
                .StartsAt(blogUserBookmarks.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Models.Blog.BlogUserBookmark>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"BlogUserBookmark_Seq\"')");
        }
    }
}
