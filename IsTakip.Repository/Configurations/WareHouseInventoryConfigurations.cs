using IsTakip.Core.Classes.WareHouseClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Configurations
{
    internal class WareHouseInventoryConfigurations : IEntityTypeConfiguration<WareHouseInventory>
    {
        public void Configure(EntityTypeBuilder<WareHouseInventory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Warehouse).WithMany(x => x.wareHouseInventories).HasForeignKey(x => x.WareHouseId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.Width).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Length).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Amount).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Weight).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Explanation).IsRequired().HasMaxLength(250);
            builder.HasOne(x => x.Supplier).WithMany(x => x.wareHouseInventories).HasForeignKey(x => x.SupplierId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Customer).WithMany(x => x.wareHouseInventories).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Shelf).WithMany(x => x.wareHouseInventories).HasForeignKey(x => x.WareHouseShelfId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
