using IsTakip.Core.Classes.WareHouseClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Configurations
{
    internal class WarehouseConfigurations : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Explanation).HasMaxLength(250);
            builder.Property(x => x.Officer).IsRequired().HasMaxLength(100);

        }
    }
}
