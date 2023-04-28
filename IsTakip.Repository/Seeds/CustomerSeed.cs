using IsTakip.Core.Classes.CustomerClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer { Id = 1, Description = "Tarlacılar AŞ.", Address = "İstinye ShoppingMall, -1. Floor, Istanbul/Turkey", UserId = 1, CustomerClassId = 1, CustomerRepresentativeId = 1, customerRestriction = Core.Classes.Enum.Enums.Restriction.Yes, Email = "tarlacılar@gmail.com", Explanation = "Outlet Store in Europian Side of Istanbul", PhoneNumber = "05447986543", TaxAdministration = "Şişli Tax Administration", TaxNumber = 1928374650 },
                new Customer { Id = 2, Description = "Akmel AŞ.", Address = "Cevahir ShoppingMall, 2. Floor, Istanbul/Turkey", UserId = 2, CustomerClassId = 2, CustomerRepresentativeId = 2, customerRestriction = Core.Classes.Enum.Enums.Restriction.No, Email = "akmel@gmail.com", Explanation = "Local Partner in Europian Side of Istanbul", PhoneNumber = "05438974562", TaxAdministration = "Besiktas Tax Administration", TaxNumber = 1928374651 },
                 new Customer { Id = 3, Description = "Teknosa", Address = "Onur OfisPark Plaza, 3. Floor, Istanbul/Turkey", UserId = 3, CustomerClassId = 1, CustomerRepresentativeId = 3, customerRestriction = Core.Classes.Enum.Enums.Restriction.Yes, Email = "teknosa@gmail.com", Explanation = "Crucial Partner in Europian Side of Istanbul", PhoneNumber = "05437674562", TaxAdministration = "Kadıköy Tax Administration", TaxNumber = 1928374653 });
        }
    }
}
