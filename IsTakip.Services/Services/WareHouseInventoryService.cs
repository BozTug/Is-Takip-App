using AutoMapper;
using IsTakip.Core.DTOs.SpecifiedDTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;

namespace IsTakip.Service.Services
{
    public class WareHouseInventoryService : Service<Core.Classes.WareHouseClasses.WareHouseInventory>, IWareHouseInventoryService
    {
        private readonly IMapper _mapper;
        private readonly IWareHouseInventoryRepository _WareHouseInventoryrepository;
        public WareHouseInventoryService(IGenericRepository<Core.Classes.WareHouseClasses.WareHouseInventory> repository, IUnitOfWork unitOfWork, IWareHouseInventoryRepository wareHouseInventoryrepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _WareHouseInventoryrepository = wareHouseInventoryrepository;
            _mapper = mapper;
        }

        public async Task<List<WareHouseInventoryWithCustomerDTO>> GetWareHouseInventoryWithCustomer()
        {
            var warehouseinventories = await _WareHouseInventoryrepository.GetWareHouseInventoryWithCustomer();
            var warehouseinventoriesDto = _mapper.Map<List<WareHouseInventoryWithCustomerDTO>>(warehouseinventories);
            return warehouseinventoriesDto;
        }



        public async Task<List<WareHouseInventoryWithSupplierDTO>> GetWareHouseInventoryWithSupplier()
        {
            var warehouseinventories = await _WareHouseInventoryrepository.GetWareHouseInventoryWithSupplier();
            var warehouseinventoriesDto = _mapper.Map<List<WareHouseInventoryWithSupplierDTO>>(warehouseinventories);
            return warehouseinventoriesDto;
        }


        public async Task<List<WareHouseInventoryWithWarehouseDTO>> GetWareHouseInventoryWithWarehouse()
        {
            var warehouseinventories = await _WareHouseInventoryrepository.GetWareHouseInventoryWithWarehouse();
            var warehouseinventoriesDto = _mapper.Map<List<WareHouseInventoryWithWarehouseDTO>>(warehouseinventories);
            return warehouseinventoriesDto;
        }


        public async Task<List<WareHouseInventoryWithWareHouseShelfDTO>> GetWareHouseInventoryWithWareHouseShelf()
        {
            var warehouseinventories = await _WareHouseInventoryrepository.GetWareHouseInventoryWithWareHouseShelf();
            var warehouseinventoriesDto = _mapper.Map<List<WareHouseInventoryWithWareHouseShelfDTO>>(warehouseinventories);
            return warehouseinventoriesDto;
        }
    }
}
