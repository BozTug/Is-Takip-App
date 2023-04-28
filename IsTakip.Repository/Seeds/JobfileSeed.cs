using IsTakip.Core.Classes.BuinessClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class JobfileSeed : IEntityTypeConfiguration<Jobfile>
    {
        public void Configure(EntityTypeBuilder<Jobfile> builder)
        {
            builder.HasData(new Jobfile { Id = 1, BusinessId = 1, JobfileName = "Order Inluding Playstations" });
        }
    }
}
