using IsTakip.Core.Classes.CustomerClasses;

namespace IsTakip.Core.Repositories
{
    public interface ICustomerClassRepository : IGenericRepository<CustomerClass>
    {
        Task<List<CustomerClass>> GetCustomerClassWithCustomer(int id);
    }
}
