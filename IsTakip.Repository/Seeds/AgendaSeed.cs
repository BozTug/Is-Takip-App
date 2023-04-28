using IsTakip.Core.Classes.CustomerClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class AgendaSeed : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasData(new Agenda { Id = 1, Explanation = "The additional information has been given to partner about their business.", CustomerId = 1 });
        }
    }
}
