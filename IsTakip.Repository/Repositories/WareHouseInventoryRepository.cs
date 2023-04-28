using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IsTakip.Repository.Repositories
{
    public class WareHouseInventoryRepository : GenericRepository<WareHouseInventory>, IWareHouseInventoryRepository
    {
        public WareHouseInventoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<WareHouseInventory>> GetWareHouseInventoryWithCustomer()
        {
            return await _context.wareHouseInventories.Include(x => x.Customer).ToListAsync();
        }


        public async Task<List<WareHouseInventory>> GetWareHouseInventoryWithSupplier()
        {
            return await _context.wareHouseInventories.Include(x => x.Supplier).ToListAsync();
        }


        public async Task<List<WareHouseInventory>> GetWareHouseInventoryWithWarehouse()
        {
            return await _context.wareHouseInventories.Include(x => x.Warehouse).ToListAsync();
        }

        public async Task<List<WareHouseInventory>> GetWareHouseInventoryWithWareHouseShelf()
        {
            return await _context.wareHouseInventories.Include(x => x.Shelf).ToListAsync();
        }
    }
}
