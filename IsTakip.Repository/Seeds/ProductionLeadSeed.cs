using IsTakip.Core.Classes.BuinessClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class ProductionLeadSeed : IEntityTypeConfiguration<ProductionLead>
    {
        public void Configure(EntityTypeBuilder<ProductionLead> builder)
        {
            builder.HasData(new ProductionLead { Id = 1, productionLeadType = Core.Classes.Enum.Enums.ProductionLeadType.ProductionNotStarted, productionOrder = Core.Classes.Enum.Enums.ProductionOrder.Done, LeadTime = 87 });
        }
    }
}
