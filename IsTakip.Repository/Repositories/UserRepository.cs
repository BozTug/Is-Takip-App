using IsTakip.Core.Classes.UserClasses;
using IsTakip.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IsTakip.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetUserWithCustomer()
        {
            return await _context.Users.Include(x => x.Customers).ToListAsync();
        }
    }
}
