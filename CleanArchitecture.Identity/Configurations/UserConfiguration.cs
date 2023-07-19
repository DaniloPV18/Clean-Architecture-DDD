using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "32b88cdc-1192-4125-b45a-05c1ed37534d",
                        Email = "admin@localhost.com",
                        NormalizedEmail = "admin@localhost.com",
                        Nombre = "Danilo",
                        Apellidos = "Pin",
                        UserName = "Nilo",
                        NormalizedUserName = "Nilo",
                        PasswordHash = hasher.HashPassword(null, "danilopin18"),
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        Id = "f03e4fb1-7249-48d0-a4a6-973a2c64ce58",
                        Email = "milo@localhost.com",
                        NormalizedEmail = "milo@localhost.com",
                        Nombre = "Fermi",
                        Apellidos = "Londra",
                        UserName = "Milo123",
                        NormalizedUserName = "Milo123",
                        PasswordHash = hasher.HashPassword(null, "danilopin18"),
                        EmailConfirmed = true
                    }
                );
        }
    }
}
