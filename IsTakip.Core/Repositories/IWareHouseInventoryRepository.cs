using IsTakip.Core.Classes.WareHouseClasses;

namespace IsTakip.Core.Repositories
{
    public interface IWareHouseInventoryRepository : IGenericRepository<WareHouseInventory>
    {



        Task<List<WareHouseInventory>> GetWareHouseInventoryWithSupplier();
        Task<List<WareHouseInventory>> GetWareHouseInventoryWithCustomer();
        Task<List<WareHouseInventory>> GetWareHouseInventoryWithWarehouse();
        Task<List<WareHouseInventory>> GetWareHouseInventoryWithWareHouseShelf();

    }
}
