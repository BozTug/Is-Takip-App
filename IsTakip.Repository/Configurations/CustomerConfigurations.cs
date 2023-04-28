using IsTakip.Core.Classes.CustomerClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Configurations
{
    internal class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.User).WithMany(x => x.Customers);
            builder.HasOne(x => x.Customerclass).WithMany(x => x.Customers).HasForeignKey(x => x.CustomerClassId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
            builder.Property(x => x.TaxAdministration).IsRequired().HasMaxLength(50);
            builder.Property(x => x.TaxNumber).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Explanation).HasMaxLength(250);
            builder.HasOne(x => x.CustomerRepresentative).WithMany(x => x.Customers).HasForeignKey(x => x.CustomerRepresentativeId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.User).WithMany(x => x.Customers).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
