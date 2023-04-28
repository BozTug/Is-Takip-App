using AutoMapper;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;

namespace IsTakip.Service.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerWithAgendaDTO>> GetCustomerWithAgenda()
        {
            var customers = await _customerRepository.GetCustomerWithAgenda();
            var customersDto = _mapper.Map<List<CustomerWithAgendaDTO>>(customers);
            return customersDto;
        }

        public async Task<List<CustomerWithBusinessDTO>> GetCustomerWithBusiness()
        {
            var customers = await _customerRepository.GetCustomerWithBusiness();
            var customersDto = _mapper.Map<List<CustomerWithBusinessDTO>>(customers);
            return customersDto;
        }

        public async Task<List<CustomerWithCustomerClassDTO>> GetCustomerWithCustomerClass()
        {
            var customers = await _customerRepository.GetCustomerWithCustomerClass();
            var customersDto = _mapper.Map<List<CustomerWithCustomerClassDTO>>(customers);
            return customersDto;
        }

        public async Task<List<CustomerWithCustomerRepresentativeDTO>> GetCustomerWithCustomerRepresentative()
        {
            var customers = await _customerRepository.GetCustomerWithCustomerRepresentative();
            var customersDto = _mapper.Map<List<CustomerWithCustomerRepresentativeDTO>>(customers);
            return customersDto;
        }



        public async Task<List<CustomerWithWareHouseInventoryDTO>> GetCustomerWithWareHouseInventory()
        {
            var customers = await _customerRepository.GetCustomerWithWareHouseInventory();
            var customersDto = _mapper.Map<List<CustomerWithWareHouseInventoryDTO>>(customers);
            return customersDto;
        }
    }
}
