using IsTakip.Core.Classes.BaseClass;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.SupplierClass;

namespace IsTakip.Core.Classes.WareHouseClasses
{
    public class WareHouseInventory : BaseEntity
    {


        public int WareHouseId { get; set; }

        public int WareHouseShelfId { get; set; }

        public Enum.Enums.MaterialType materialType { get; set; }

        public Enum.Enums.Thickness thickness { get; set; }

        public float Width { get; set; }

        public float Length { get; set; }

        public float Amount { get; set; }

        public float Weight { get; set; }

        public string Explanation { get; set; }

        public Warehouse Warehouse { get; set; }
        public WareHouseShelf Shelf { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
