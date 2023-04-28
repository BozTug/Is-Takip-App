using IsTakip.Core.Classes.CustomerClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Configurations
{
    internal class AgendaConfigurations : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Explanation).IsRequired().HasMaxLength(250);
            builder.HasOne(x => x.Customer).WithMany(x => x.Agenda).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
