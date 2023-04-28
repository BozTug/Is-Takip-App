using AutoMapper;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;

namespace IsTakip.Service.Services
{
    public class CustomerClassService : Service<CustomerClass>, ICustomerClassService
    {
        private readonly ICustomerClassRepository _customerClassRepository;
        private readonly IMapper _mapper;
        public CustomerClassService(IGenericRepository<CustomerClass> repository, IUnitOfWork unitOfWork, IMapper mapper, ICustomerClassRepository customerClassRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _customerClassRepository = customerClassRepository;
        }

        public async Task<List<CustomerClassWithCustomerDTO>> GetCustomerClassWithCustomer(int id)
        {
            var customerclasses = await _customerClassRepository.GetCustomerClassWithCustomer(id);
            var customerclassesDto = _mapper.Map<List<CustomerClassWithCustomerDTO>>(customerclasses);
            return customerclassesDto;
        }
    }
}
