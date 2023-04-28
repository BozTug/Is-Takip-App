using AutoMapper;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;

namespace IsTakip.Service.Services
{
    public class BusinessService : Service<Business>, IBusinessService
    {
        private readonly IMapper _mapper;
        private readonly IBusinessRepository _businessRepository;
        public BusinessService(IGenericRepository<Business> repository, IUnitOfWork unitOfWork, IBusinessRepository businessRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _businessRepository = businessRepository;
            _mapper = mapper;
        }

        public async Task<List<BusinessWithCustomerDTO>> GetBusinessWithCustomer(int id)
        {
            var businesses = await _businessRepository.GetBusinessWithCustomer(id);
            var businessesDto = _mapper.Map<List<BusinessWithCustomerDTO>>(businesses);
            return businessesDto;
        }

        public async Task<List<BusinessWithJobfileDTO>> GetBusinessWithJobfile()
        {
            var businesses = await _businessRepository.GetBusinessWithJobfile();
            var businessesDto = _mapper.Map<List<BusinessWithJobfileDTO>>(businesses);
            return businessesDto;
        }




        public async Task<List<BusinessWithSupplierDTO>> GetBusinessWithSupplier()
        {
            var businesses = await _businessRepository.GetBusinessWithSupplier();
            var businessesDto = _mapper.Map<List<BusinessWithSupplierDTO>>(businesses);
            return businessesDto;
        }


    }
}
