using IsTakip.Core.Classes.WareHouseClasses;

namespace IsTakip.Core.Repositories
{
    public interface IWarehouseRepository : IGenericRepository<Warehouse>
    {
        Task<List<Warehouse>> GetWarehouseWithWareHouseInventory();

        Task<List<Warehouse>> GetWarehouseWithWareHouseShelf();
    }
}
