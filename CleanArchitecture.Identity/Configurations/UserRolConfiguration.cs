using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRolConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "15da6cb8-df86-4549-906f-98e7287208eb",
                    UserId = "32b88cdc-1192-4125-b45a-05c1ed37534d"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "45c4a166-a4fd-476c-9b95-c78571587837",
                    UserId = "f03e4fb1-7249-48d0-a4a6-973a2c64ce58"
                }
            );
        }
    }
}
