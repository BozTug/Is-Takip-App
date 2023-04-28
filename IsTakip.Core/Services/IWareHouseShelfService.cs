using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;

namespace IsTakip.Core.Services
{
    public interface IWareHouseShelfService : IService<WareHouseShelf>
    {
        Task<List<WareHouseShelfWithWarehouseDTO>> GetWareHouseShelfWithWarehouse();
        Task<List<WareHouseShelfWithWareHouseInventoryDTO>> GetWareHouseShelfWithWarehouseInventory();
    }
}
