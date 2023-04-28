namespace IsTakip.Core.DTOs.SpecifiedDTOs
{
    public class CustomerWithWareHouseInventoryDTO : CustomerDTO
    {
        public WareHouseInventoryDTO wareHouseInventory { get; set; }
    }
}
