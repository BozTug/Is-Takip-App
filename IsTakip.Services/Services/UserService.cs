using AutoMapper;
using IsTakip.Core.Classes.UserClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;

namespace IsTakip.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<UserWithCustomerDTO>> GetUserWithCustomer()
        {
            var users = await _userRepository.GetUserWithCustomer();
            var usersDto = _mapper.Map<List<UserWithCustomerDTO>>(users);
            return usersDto;
        }
    }
}
