using IsTakip.Core.Classes.BuinessClasses;

namespace IsTakip.Core.Repositories
{
    public interface IJobfileRepository : IGenericRepository<Jobfile>
    {
        Task<List<Jobfile>> GetJobfileWithBusiness();

    }
}
