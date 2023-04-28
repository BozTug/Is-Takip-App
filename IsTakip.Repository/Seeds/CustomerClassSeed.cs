using IsTakip.Core.Classes.CustomerClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class CustomerClassSeed : IEntityTypeConfiguration<CustomerClass>
    {
        public void Configure(EntityTypeBuilder<CustomerClass> builder)
        {
            builder.HasData(new CustomerClass { Id = 1, Description = "Key Accounts", Explanation = "Partial Partners for our Company" },
                new CustomerClass { Id = 2, Description = "Channel Accounts", Explanation = "Local Partners for our Company" }
                );
        }
    }
}
