using Microsoft.EntityFrameworkCore;

namespace Resty.Data.Seeds.Blog
{
    internal static class TagSeed
    {
        public static void SeedTags(this ModelBuilder modelBuilder)
        {
            var tags = new[]
            {
                new Models.Blog.Tag
                {
                    Id = 1,
                    Title = "C#"
                },

                new Models.Blog.Tag
                {
                    Id = 2,
                    Title = ".NET 6"
                },

                new Models.Blog.Tag
                {
                    Id = 3,
                    Title = "PostgreSQL"
                },

                new Models.Blog.Tag
                {
                    Id = 4,
                    Title = "SignalR"
                },

                new Models.Blog.Tag
                {
                    Id = 5,
                    Title = "Web-design"
                },

                new Models.Blog.Tag
                {
                    Id = 6,
                    Title = "Android"
                },

                new Models.Blog.Tag
                {
                    Id = 7,
                    Title = "IT-companies"
                },

                new Models.Blog.Tag
                {
                    Id = 8,
                    Title = "Security"
                },
            };

            modelBuilder.Entity<Models.Blog.Tag>().HasData(tags);

            modelBuilder.HasSequence<int>("Tags_Seq", schema: "public")
                .StartsAt(tags.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Models.Blog.Tag>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"Tags_Seq\"')");
        }
    }
}
