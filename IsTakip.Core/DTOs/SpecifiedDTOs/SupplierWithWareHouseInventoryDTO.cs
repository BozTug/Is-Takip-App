namespace IsTakip.Core.DTOs.SpecifiedDTOs
{
    public class SupplierWithWareHouseInventoryDTO : SupplierDTO
    {
        public WareHouseInventoryDTO WareHouseInventory { get; set; }
    }
}
