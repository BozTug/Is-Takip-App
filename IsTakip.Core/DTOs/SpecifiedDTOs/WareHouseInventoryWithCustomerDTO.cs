namespace IsTakip.Core.DTOs.SpecifiedDTOs
{
    public class WareHouseInventoryWithCustomerDTO : WareHouseInventoryDTO
    {
        public CustomerDTO Customer { get; set; }
    }
}
