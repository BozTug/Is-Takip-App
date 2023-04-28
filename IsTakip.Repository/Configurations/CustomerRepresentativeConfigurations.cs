using IsTakip.Core.Classes.CustomerClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Configurations
{
    internal class CustomerRepresentativeConfigurations : IEntityTypeConfiguration<CustomerRepresentative>
    {
        public void Configure(EntityTypeBuilder<CustomerRepresentative> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(25);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(25);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(25);



        }
    }
}
