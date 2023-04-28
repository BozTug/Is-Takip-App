using IsTakip.Core.Classes.WareHouseClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class WareHouseInventorySeed : IEntityTypeConfiguration<WareHouseInventory>
    {
        public void Configure(EntityTypeBuilder<WareHouseInventory> builder)
        {
            builder.HasData(new WareHouseInventory { Id = 1, CustomerId = 1, materialType = Core.Classes.Enum.Enums.MaterialType.Wood, SupplierId = 1, thickness = Core.Classes.Enum.Enums.Thickness.Thin, WareHouseId = 1, WareHouseShelfId = 1, Width = 12.5f, Length = 10.2f, Amount = 2.3f, Weight = 0.6f, Explanation = "There is sufficient stock." });
        }
    }
}
