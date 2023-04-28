using IsTakip.Core.Classes.BaseClass;

namespace IsTakip.Core.Classes.WareHouseClasses
{
    public class Warehouse : BaseEntity
    {


        public string Description { get; set; }

        public string Explanation { get; set; }

        public string Officer { get; set; }

        public string OfficerPhone { get; set; }

        public ICollection<WareHouseShelf> Shelfs { get; set; }
        public ICollection<WareHouseInventory> wareHouseInventories { get; set; }
    }
}
