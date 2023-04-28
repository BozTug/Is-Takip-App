using IsTakip.Core.Classes.UserClasses;

namespace IsTakip.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {

        Task<List<User>> GetUserWithCustomer();
    }
}
