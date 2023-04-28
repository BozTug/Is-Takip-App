using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;

namespace IsTakip.Core.Services
{
    public interface IWarehouseService : IService<Warehouse>
    {
        Task<List<WarehouseWithWareHouseInventoryDTO>> GetWarehouseWithWareHouseInventory();
        Task<List<WarehouseWithWareHouseShelfDTO>> GetWarehouseWithWareHouseShelf();
    }
}
