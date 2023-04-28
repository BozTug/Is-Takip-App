using IsTakip.Core.Classes.BaseClass;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.WareHouseClasses;

namespace IsTakip.Core.Classes.SupplierClass
{
    public class Supplier : BaseEntity
    {


        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Explanation { get; set; }

        public ICollection<WareHouseInventory> wareHouseInventories { get; set; }

        public ICollection<Business> businesses { get; set; }


    }
}
