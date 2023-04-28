using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IsTakip.Repository.Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Warehouse>> GetWarehouseWithWareHouseInventory()
        {
            return await _context.Warehouses.Include(x => x.wareHouseInventories).ToListAsync();
        }

        public async Task<List<Warehouse>> GetWarehouseWithWareHouseShelf()
        {
            return await _context.Warehouses.Include(x => x.Shelfs).ToListAsync();
        }
    }
}
