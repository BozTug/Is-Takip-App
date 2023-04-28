using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IsTakip.Repository.Repositories
{
    public class BusinessRepository : GenericRepository<Business>, IBusinessRepository
    {
        public BusinessRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Business>> GetBusinessWithCustomer(int id)
        {
            return await _context.Businesses.Include(x => x.Customer).ToListAsync();
        }

        public async Task<List<Business>> GetBusinessWithJobfile()
        {
            return await _context.Businesses.Include(x => x.Jobfile).ToListAsync();
        }



        public async Task<List<Business>> GetBusinessWithSupplier()
        {
            return await _context.Businesses.Include(x => x.Supplier).ToListAsync();
        }


    }
}
