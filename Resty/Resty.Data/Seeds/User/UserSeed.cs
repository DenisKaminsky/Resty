using Microsoft.EntityFrameworkCore;
using Resty.Core.Enums;

namespace Resty.Data.Seeds.User
{
    internal static class UserSeed
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            //md5Hash. Password is "admin"
            var passwordHash = "21232f297a57a5a743894a0e4a801fc3";
            var users = new[]
            {
                new Models.User.User 
                { 
                    Id = 1, 
                    Username = "DenisAdmin",
                    FirstName = "Denis", 
                    LastName = "Kaminsky", 
                    Email = "deniskaminsky123@mail.ru",
                    PasswordHash = passwordHash,
                    StartDateUtc = DateTime.UtcNow.AddDays(-100),
                    Rating = 900,
                    RoleId = (int)UserRoles.Admin
                },

                new Models.User.User
                {
                    Id = 2,
                    Username = "DenisGuest",
                    FirstName = "Denis",
                    LastName = "KaminskyGuest",
                    Email = "deniskaminskyGuest@mail.ru",
                    PasswordHash = passwordHash,
                    StartDateUtc = DateTime.UtcNow.AddDays(-10),
                    Rating = 1,
                    RoleId = (int)UserRoles.GuestUser
                },

                new Models.User.User
                {
                    Id = 3,
                    Username = "DenisPrime",
                    FirstName = "Denis",
                    LastName = "KaminskyPrime",
                    Email = "deniskaminskyPrime@mail.ru",
                    PasswordHash = passwordHash,
                    StartDateUtc = DateTime.UtcNow.AddDays(-5),
                    Rating = 3,
                    RoleId = (int)UserRoles.PrimeUser
                }
            };

            modelBuilder.Entity<Models.User.User>().HasData(users);

            modelBuilder.HasSequence<int>("Users_Seq", schema: "public")
                .StartsAt(users.Max(x => x.Id) + 1)
                .IncrementsBy(1);

            modelBuilder.Entity<Models.User.User>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"Users_Seq\"')");
        }
    }
}
