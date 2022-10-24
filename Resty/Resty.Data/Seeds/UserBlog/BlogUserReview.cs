using Microsoft.EntityFrameworkCore;

namespace Resty.Data.Seeds.UserBlog
{
    internal static class BlogUserReviewSeed
    {
        public static void SeedBlogUserReviews(this ModelBuilder modelBuilder)
        {
            var users = new[]
            {
                new Models.Blog.BlogUserReview
                {
                    Id = 1,
                    UserId = 1,
                    BlogId = 2,
                    Grade = 0
                },

                new Models.Blog.BlogUserReview
                {
                    Id = 2,
                    UserId = 1,
                    BlogId = 3,
                    Grade = 1
                },

                new Models.Blog.BlogUserReview
                {
                    Id = 3,
                    UserId = 2,
                    BlogId = 1,
                    Grade = 1
                },

                new Models.Blog.BlogUserReview
                {
                    Id = 4,
                    UserId = 2,
                    BlogId = 3,
                    Grade = 1
                },

                new Models.Blog.BlogUserReview
                {
                    Id = 5,
                    UserId = 3,
                    BlogId = 1,
                    Grade = 0
                },

                new Models.Blog.BlogUserReview
                {
                    Id = 6,
                    UserId = 3,
                    BlogId = 2,
                    Grade = -1
                }
            };

            modelBuilder.Entity<Models.Blog.BlogUserReview>().HasData(users);

            modelBuilder.HasSequence<int>("BlogUserReview_Seq", schema: "public")
                .StartsAt(users.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Models.Blog.BlogUserReview>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"BlogUserReview_Seq\"')");
        }
    }
}
