using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IsTakip.Repository.Repositories
{
    public class JobfileRepository : GenericRepository<Jobfile>, IJobfileRepository
    {
        public JobfileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Jobfile>> GetJobfileWithBusiness()
        {
            return await _context.Jobfiles.Include(x => x.Business).ToListAsync();
        }
    }
}
