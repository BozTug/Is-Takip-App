using IsTakip.Core.Classes.BaseClass;

namespace IsTakip.Core.Classes.WareHouseClasses
{
    public class WareHouseShelf : BaseEntity
    {


        public string Description { get; set; }

        public string Explanation { get; set; }

        public int WareHouseId { get; set; }

        public Warehouse Warehouse { get; set; }
        public ICollection<WareHouseInventory> wareHouseInventories { get; set; }
    }
}
