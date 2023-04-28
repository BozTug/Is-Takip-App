using IsTakip.Core.Classes.BaseClass;

namespace IsTakip.Core.Classes.UserClasses
{
    public class MailParameters : BaseEntity
    {
        public int Id { get; set; }

        public string SenderName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string SmtpAddress { get; set; }

        public string SmtpPort { get; set; }

        public string SSL { get; set; }
    }
}
