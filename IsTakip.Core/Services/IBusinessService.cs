using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;

namespace IsTakip.Core.Services
{
    public interface IBusinessService : IService<Business>
    {
        Task<List<BusinessWithCustomerDTO>> GetBusinessWithCustomer(int id);
        Task<List<BusinessWithJobfileDTO>> GetBusinessWithJobfile();

        Task<List<BusinessWithSupplierDTO>> GetBusinessWithSupplier();


    }
}
