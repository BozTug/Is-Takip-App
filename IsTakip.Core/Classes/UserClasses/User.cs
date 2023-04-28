using IsTakip.Core.Classes.BaseClass;
using IsTakip.Core.Classes.CustomerClasses;
using static IsTakip.Core.Classes.Enum.Enums;

namespace IsTakip.Core.Classes.UserClasses
{
    public class User : BaseEntity
    {


        public string Name { get; set; }
        public string Surname { get; set; }

        public int CustomerId { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public string UserCode { get; set; }

        public string UserPassword { get; set; }
        public RoleDescription RoleDescription { get; set; }

        public MailNotification MailNotification { get; set; }
    }
}
