using IsTakip.Core.Classes.UserClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;

namespace IsTakip.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<List<UserWithCustomerDTO>> GetUserWithCustomer();
    }
}
