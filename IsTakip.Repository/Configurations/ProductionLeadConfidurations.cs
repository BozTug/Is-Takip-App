using IsTakip.Core.Classes.BuinessClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Configurations
{
    internal class ProductionLeadConfidurations : IEntityTypeConfiguration<ProductionLead>
    {
        public void Configure(EntityTypeBuilder<ProductionLead> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

        }
    }
}
