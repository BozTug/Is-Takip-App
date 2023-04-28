using IsTakip.Core.Classes.BuinessClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class BusinessSeed : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasData(new Business
            {
                Id = 1,
                BusinessNote = "It should be delivered within one week",
                BusinessPriority = Core.Classes.Enum.Enums.BusinessPriority.High,
                CustomerId = 1,
                CustomerOrderNo = 0001,
                materialType = Core.Classes.Enum.Enums.MaterialType.Wood,
                OfferNo = 89765432,
                Price = 250.00m,
                SupplierId = 1,
                thickness = Core.Classes.Enum.Enums.Thickness.Thick,
                Workmanship = Core.Classes.Enum.Enums.Workmanship.Yes,
                EndNoticeSituation = Core.Classes.Enum.Enums.EndNoticeSituation.Yes,
                OfferType = Core.Classes.Enum.Enums.OfferType.WithOffer,
                MaterialNote = "There is no additional İnformation."
            });
        }
    }
}
