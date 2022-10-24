using Microsoft.EntityFrameworkCore;

namespace Resty.Data.Seeds.UserBlog
{
    internal static class BlogUserCommentSeed
    {
        public static void SeedBlogUserComments(this ModelBuilder modelBuilder)
        {
            var blogUserComments = new[]
            {
                new Models.Blog.BlogUserComment 
                { 
                    Id = 1,
                    UserId = 2,
                    BlogId = 1,
                    CommentText = "Comment from DenisGuest"
                },

                new Models.Blog.BlogUserComment
                {
                    Id = 2,
                    UserId = 3,
                    BlogId = 1,
                    CommentText = "Comment from DenisPrime"
                },
            };

            modelBuilder.Entity<Models.Blog.BlogUserComment>().HasData(blogUserComments);

            modelBuilder.HasSequence<int>("BlogUserComment_Seq", schema: "public")
                .StartsAt(blogUserComments.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Models.Blog.BlogUserComment>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"BlogUserComment_Seq\"')");
        }
    }
}
