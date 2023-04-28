using IsTakip.Core.Classes.CustomerClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Configurations
{
    internal class CustomerClassConfiguration : IEntityTypeConfiguration<CustomerClass>
    {
        public void Configure(EntityTypeBuilder<CustomerClass> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Explanation).HasMaxLength(250);
        }
    }
}
