using IsTakip.Core.Classes.BuinessClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Configurations
{
    internal class BusinessConfigurations : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.OfferNo).IsRequired().HasMaxLength(25);
            builder.Property(x => x.CustomerOrderNo).IsRequired().HasMaxLength(25);
            builder.Property(x => x.BusinessNote).IsRequired().HasMaxLength(250);

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Customer).WithMany(x => x.Businesses).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.MaterialNote).IsRequired().HasMaxLength(100);
            builder.HasOne(x => x.Supplier).WithMany(x => x.businesses).HasForeignKey(x => x.SupplierId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
