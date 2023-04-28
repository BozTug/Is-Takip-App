using IsTakip.Core.Classes.SupplierClass;
using IsTakip.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IsTakip.Repository.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Supplier>> GetSupplierWithBusiness()
        {
            return await _context.Suppliers.Include(x => x.businesses).ToListAsync();
        }

        public async Task<List<Supplier>> GetSupplierWithWareHouseInventory()
        {
            return await _context.Suppliers.Include(x => x.wareHouseInventories).ToListAsync();
        }
    }
}
