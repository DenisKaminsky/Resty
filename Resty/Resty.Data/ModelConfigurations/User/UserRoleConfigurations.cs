using Microsoft.EntityFrameworkCore;
using Resty.Core.Constraints.User;
using Resty.Data.Models.User;

namespace Resty.Data.ModelConfigurations.User
{
    internal static class UserRoleConfigurations
    {
        internal static void ConfigureUserRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<UserRole>()
                .Property(x => x.Name)
                .HasMaxLength(UserRoleConstraints.NameMaxLength)
                .IsRequired();
        }
    }
}
