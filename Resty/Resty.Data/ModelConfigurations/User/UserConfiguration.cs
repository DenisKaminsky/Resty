using Microsoft.EntityFrameworkCore;
using Resty.Core.Constraints.User;

namespace Resty.Data.ModelConfigurations.User
{
    internal static class UserConfiguration
    {
        internal static void ConfigureUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.User.User>()
                .HasIndex(x => x.Rating);

            modelBuilder.Entity<Models.User.User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<Models.User.User>()
                .Property(x => x.Username)
                .HasMaxLength(UserConstraints.UsernameMaxLength)
                .IsRequired();

            modelBuilder.Entity<Models.User.User>()
                .Property(x => x.FirstName)
                .HasMaxLength(UserConstraints.FirstNameMaxLength)
                .IsRequired();

            modelBuilder.Entity<Models.User.User>()
                .Property(x => x.LastName)
                .HasMaxLength(UserConstraints.LastNameMaxLength)
                .IsRequired();

            modelBuilder.Entity<Models.User.User>()
                .Property(x => x.Email)
                .HasMaxLength(UserConstraints.EmailMaxLength)
                .IsRequired();

            modelBuilder.Entity<Models.User.User>()
                .Property(x => x.PasswordHash)
                .HasMaxLength(UserConstraints.PasswordHashLength)
                .IsRequired();
        }
    }
}
