using IsTakip.Core.Classes.WareHouseClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class WareHouseShelfSeed : IEntityTypeConfiguration<WareHouseShelf>
    {
        public void Configure(EntityTypeBuilder<WareHouseShelf> builder)
        {
            builder.HasData(new WareHouseShelf { Id = 1, WareHouseId = 1, Description = "Block A", Explanation = "Electronical Side" });
        }
    }
}
