using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;

namespace IsTakip.Core.Services
{
    public interface ICustomerClassService : IService<CustomerClass>
    {
     
        Task<List<CustomerClassWithCustomerDTO>> GetCustomerClassWithCustomer(int id);
    }
}
