using AutoMapper;
using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;

namespace IsTakip.Service.Services
{
    public class WarehouseService : Service<Warehouse>, IWarehouseService
    {
        private readonly IMapper _mapper;
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseService(IGenericRepository<Warehouse> repository, IUnitOfWork unitOfWork, IWarehouseRepository warehouseRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public async Task<List<WarehouseWithWareHouseInventoryDTO>> GetWarehouseWithWareHouseInventory()
        {
            var warehouses = await _warehouseRepository.GetWarehouseWithWareHouseInventory();
            var warehousesDto = _mapper.Map<List<WarehouseWithWareHouseInventoryDTO>>(warehouses);
            return warehousesDto;
        }

        public async Task<List<WarehouseWithWareHouseShelfDTO>> GetWarehouseWithWareHouseShelf()
        {
            var warehouses = await _warehouseRepository.GetWarehouseWithWareHouseShelf();
            var warehousesDto = _mapper.Map<List<WarehouseWithWareHouseShelfDTO>>(warehouses);
            return warehousesDto;
        }
    }
}
