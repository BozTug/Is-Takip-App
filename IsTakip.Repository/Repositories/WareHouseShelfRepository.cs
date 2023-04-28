using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IsTakip.Repository.Repositories
{
    public class WareHouseShelfRepository : GenericRepository<WareHouseShelf>, IWareHouseShelfRepository
    {
        public WareHouseShelfRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<WareHouseShelf>> GetWareHouseShelfWithWarehouse()
        {
            return await _context.wareHouseShelves.Include(x => x.Warehouse).ToListAsync();
        }

        public async Task<List<WareHouseShelf>> GetWareHouseShelfWithWareHouseInventory()
        {
            return await _context.wareHouseShelves.Include(x => x.wareHouseInventories).ToListAsync();
        }
    }
}
