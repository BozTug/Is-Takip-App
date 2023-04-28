using AutoMapper;
using IsTakip.Core.Classes.SupplierClass;
using IsTakip.Core.DTOs.SpecifiedDTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;

namespace IsTakip.Service.Services
{
    public class SupplierService : Service<Supplier>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public SupplierService(IGenericRepository<Supplier> repository, IUnitOfWork unitOfWork, IMapper mapper, ISupplierRepository supplierRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<List<SupplierWithBusinessDTO>> GetSupplierWithBusiness()
        {
            var suppliers = await _supplierRepository.GetSupplierWithBusiness();
            var suppliersDto = _mapper.Map<List<SupplierWithBusinessDTO>>(suppliers);
            return suppliersDto;
        }

        public async Task<List<SupplierWithWareHouseInventoryDTO>> GetSupplierWithWareHouseInventory()
        {
            var suppliers = await _supplierRepository.GetSupplierWithWareHouseInventory();
            var suppliersDto = _mapper.Map<List<SupplierWithWareHouseInventoryDTO>>(suppliers);
            return suppliersDto;
        }
    }
}
