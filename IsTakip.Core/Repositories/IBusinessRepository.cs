using IsTakip.Core.Classes.BuinessClasses;

namespace IsTakip.Core.Repositories
{
    public interface IBusinessRepository : IGenericRepository<Business>
    {
        Task<List<Business>> GetBusinessWithCustomer(int id);

        Task<List<Business>> GetBusinessWithSupplier();
        Task<List<Business>> GetBusinessWithJobfile();


    }
}
