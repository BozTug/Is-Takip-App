using IsTakip.Core.Classes.CustomerClasses;

namespace IsTakip.Core.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<List<Customer>> GetCustomerWithCustomerClass();


        Task<List<Customer>> GetCustomerWithBusiness();

        Task<List<Customer>> GetCustomerWithCustomerRepresentative();

        Task<List<Customer>> GetCustomerWithAgenda();

        Task<List<Customer>> GetCustomerWithWareHouseInventory();

        Task<List<Customer>> GetCustomerWithUser();

    }
}
