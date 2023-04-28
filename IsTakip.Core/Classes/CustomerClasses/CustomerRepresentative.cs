using IsTakip.Core.Classes.BaseClass;

namespace IsTakip.Core.Classes.CustomerClasses
{
    public class CustomerRepresentative : BaseEntity
    {


        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int CustomerId { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
