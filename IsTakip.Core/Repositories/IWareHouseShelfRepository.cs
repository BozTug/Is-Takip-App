using IsTakip.Core.Classes.WareHouseClasses;

namespace IsTakip.Core.Repositories
{
    public interface IWareHouseShelfRepository : IGenericRepository<WareHouseShelf>
    {
        Task<List<WareHouseShelf>> GetWareHouseShelfWithWarehouse();

        Task<List<WareHouseShelf>> GetWareHouseShelfWithWareHouseInventory();
    }
}
