using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IsTakip.Repository.Repositories
{
    public class CustomerClassRepository : GenericRepository<CustomerClass>, ICustomerClassRepository
    {
        public CustomerClassRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<List<CustomerClass>> GetCustomerClassWithCustomer(int id)
        {
            return await _context.CustomerClasses.Include(x => x.Customers).ToListAsync();
        }

    }
}
