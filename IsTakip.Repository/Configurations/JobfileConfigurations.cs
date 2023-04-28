using IsTakip.Core.Classes.BuinessClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Configurations
{
    internal class JobFileConfigurations : IEntityTypeConfiguration<Jobfile>
    {
        public void Configure(EntityTypeBuilder<Jobfile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.JobfileName).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.Business).WithOne(x => x.Jobfile).HasForeignKey<Jobfile>(x => x.BusinessId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
