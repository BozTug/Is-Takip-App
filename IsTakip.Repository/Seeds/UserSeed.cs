using IsTakip.Core.Classes.UserClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsTakip.Repository.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User { CustomerId = 1, Id = 1, Name = "Kemal", Surname = "Öztürk", UserCode = "Kemalztrk", UserPassword = "Kemal1234", RoleDescription = Core.Classes.Enum.Enums.RoleDescription.Admin, MailNotification = Core.Classes.Enum.Enums.MailNotification.Yes },
                new User { CustomerId = 2, Id = 2, Name = "Eray", Surname = "Baydur", UserCode = "Eraybydr", UserPassword = "Eray1234", RoleDescription = Core.Classes.Enum.Enums.RoleDescription.Manager, MailNotification = Core.Classes.Enum.Enums.MailNotification.No },
                new User { CustomerId = 3, Id = 3, Name = "Serkan", Surname = "Kılıçkap", UserCode = "Serkanklnckp", UserPassword = "Serkan1234", RoleDescription = Core.Classes.Enum.Enums.RoleDescription.Sales, MailNotification = Core.Classes.Enum.Enums.MailNotification.Yes });
        }
    }
}
