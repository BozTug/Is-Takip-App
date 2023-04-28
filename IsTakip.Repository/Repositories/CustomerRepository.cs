using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IsTakip.Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Customer>> GetCustomerWithAgenda()
        {
            return await _context.Customers.Include(x => x.Agenda).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomerWithBusiness()
        {
            return await _context.Customers.Include(x => x.Businesses).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomerWithCustomerClass()
        {
            return await _context.Customers.Include(x => x.Customerclass).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomerWithCustomerRepresentative()
        {
            return await _context.Customers.Include(x => x.CustomerRepresentative).ToListAsync();
        }


        public async Task<List<Customer>> GetCustomerWithUser()
        {
            return await _context.Customers.Include(x => x.User).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomerWithWareHouseInventory()
        {
            return await _context.Customers.Include(x => x.wareHouseInventories).ToListAsync();
        }


    }
}
