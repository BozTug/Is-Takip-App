using AutoMapper;
using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;

namespace IsTakip.Service.Services
{
    public class WareHouseShelfService : Service<WareHouseShelf>, IWareHouseShelfService
    {
        private readonly IMapper _mapper;
        private readonly IWareHouseShelfRepository _warehouseshelfrepository;
        public WareHouseShelfService(IGenericRepository<WareHouseShelf> repository, IUnitOfWork unitOfWork, IMapper mapper, IWareHouseShelfRepository warehouseshelfrepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _warehouseshelfrepository = warehouseshelfrepository;
        }

        public async Task<List<WareHouseShelfWithWarehouseDTO>> GetWareHouseShelfWithWarehouse()
        {
            var warehouseshelves = await _warehouseshelfrepository.GetWareHouseShelfWithWarehouse();
            var warehouseshelvesDto = _mapper.Map<List<WareHouseShelfWithWarehouseDTO>>(warehouseshelves);
            return warehouseshelvesDto;
        }

        public async Task<List<WareHouseShelfWithWareHouseInventoryDTO>> GetWareHouseShelfWithWarehouseInventory()
        {
            var warehouseshelves = await _warehouseshelfrepository.GetWareHouseShelfWithWareHouseInventory();
            var warehouseshelvesDto = _mapper.Map<List<WareHouseShelfWithWareHouseInventoryDTO>>(warehouseshelves);
            return warehouseshelvesDto;
        }
    }
}
