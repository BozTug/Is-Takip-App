using IsTakip.Core.Classes.WareHouseClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class WarehouseSeed : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasData(new Warehouse { Id = 1, Description = "SONY Warehouse", Explanation = "Electronical Side", Officer = "Ziya Duran", OfficerPhone = "05436785432" });
        }
    }
}
