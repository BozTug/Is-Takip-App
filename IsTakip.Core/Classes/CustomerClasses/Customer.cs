using IsTakip.Core.Classes.BaseClass;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.UserClasses;
using IsTakip.Core.Classes.WareHouseClasses;

namespace IsTakip.Core.Classes.CustomerClasses
{
    public class Customer : BaseEntity
    {


        public string Description { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxAdministration { get; set; }
        public int TaxNumber { get; set; }

        public string? Explanation { get; set; }

        public int CustomerClassId { get; set; }

        public CustomerClass Customerclass { get; set; }

        public Enum.Enums.Restriction customerRestriction { get; set; }



        public int CustomerRepresentativeId { get; set; }

        public CustomerRepresentative CustomerRepresentative { get; set; }

        public ICollection<Agenda> Agenda { get; set; }

        public ICollection<Business> Businesses { get; }

        public ICollection<WareHouseInventory> wareHouseInventories { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}
