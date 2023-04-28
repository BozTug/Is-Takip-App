using IsTakip.Core.Classes.BaseClass;

namespace IsTakip.Core.Classes.CustomerClasses
{
    public class Agenda : BaseEntity
    {


        public int CustomerId { get; set; }
        public string Explanation { get; set; }



        public Customer Customer { get; set; }
    }
}
