using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;

namespace IsTakip.Core.Services
{
    public interface IWareHouseInventoryService : IService<WareHouseInventory>
    {
        Task<List<WareHouseInventoryWithCustomerDTO>> GetWareHouseInventoryWithCustomer();

        Task<List<WareHouseInventoryWithSupplierDTO>> GetWareHouseInventoryWithSupplier();

        Task<List<WareHouseInventoryWithWarehouseDTO>> GetWareHouseInventoryWithWarehouse();
        Task<List<WareHouseInventoryWithWareHouseShelfDTO>> GetWareHouseInventoryWithWareHouseShelf();

    }
}
