using IsTakip.Core.Classes.SupplierClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class SupplierSeed : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(new Supplier { Id = 1, Description = "SONY Turkey", Email = "sonyturkey@sony.com", PhoneNumber = "02169875643", Explanation = "Supplier for Electronic stuff. " });
        }
    }
}
