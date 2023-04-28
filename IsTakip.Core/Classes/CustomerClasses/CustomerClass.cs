using IsTakip.Core.Classes.BaseClass;

namespace IsTakip.Core.Classes.CustomerClasses
{
    public class CustomerClass : BaseEntity
    {

        public string Description { get; set; }

        public string Explanation { get; set; }



        public ICollection<Customer> Customers { get; set; }
    }
}
