using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;

namespace IsTakip.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
        Task<List<CustomerWithCustomerClassDTO>> GetCustomerWithCustomerClass();

        Task<List<CustomerWithAgendaDTO>> GetCustomerWithAgenda();

        Task<List<CustomerWithBusinessDTO>> GetCustomerWithBusiness();

        Task<List<CustomerWithCustomerRepresentativeDTO>> GetCustomerWithCustomerRepresentative();



        Task<List<CustomerWithWareHouseInventoryDTO>> GetCustomerWithWareHouseInventory();
        
    }
}
