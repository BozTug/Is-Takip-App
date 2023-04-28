using IsTakip.Core.Classes.UserClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Configurations
{
    internal class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(25);
            builder.Property(x => x.UserCode).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserPassword).IsRequired().HasMaxLength(50);
            builder.Property(x => x.RoleDescription).IsRequired().HasMaxLength(50);

        }
    }
}
