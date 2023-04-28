using static IsTakip.Core.Classes.Enum.Enums;

namespace IsTakip.Core.DTOs
{
    public class UserDTO : BaseDTO
    {


        public string Name { get; set; }
        public string Surname { get; set; }

        public int CustomerId { get; set; }
        public string UserCode { get; set; }

        public string UserPassword { get; set; }
        public string RoleDescription { get; set; }

        public MailNotification MailNotification { get; set; }
    }
}
