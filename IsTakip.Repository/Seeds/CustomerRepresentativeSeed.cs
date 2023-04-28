using IsTakip.Core.Classes.CustomerClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class CustomerRepresentativeSeed : IEntityTypeConfiguration<CustomerRepresentative>
    {
        public void Configure(EntityTypeBuilder<CustomerRepresentative> builder)
        {
            builder.HasData(new CustomerRepresentative { Id = 1, Name = "Kemal", Surname = "Öztürk", Email = "kemalozturk@gmail.com", PhoneNumber = "05302427531", CustomerId = 1 },
                new CustomerRepresentative { Id = 2, Name = "Eray", Surname = "Baydur", Email = "eraybaydur@gmail.com", PhoneNumber = "05302486592", CustomerId = 2 },
                new CustomerRepresentative { Id = 3, Name = "Serkan", Surname = "Kılıçkap", Email = "serkanklnckp@gmail.com", PhoneNumber = "05362428531", CustomerId = 3 });
        }
    }
}
