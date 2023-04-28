using AutoMapper;
using IsTakip.API.Filters;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : CustomBaseController
    {
        private readonly IMapper _mapper;
      
        private readonly IWarehouseService _services;

        public WarehouseController(IMapper mapper,  IWarehouseService warehouseService)
        {
            _mapper = mapper;
           
            _services = warehouseService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWarehouseWithWareHouseShelf()
        {
            return CreateActionResult(await _services.GetWarehouseWithWareHouseShelf());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWarehouseWithWareHouseInventory()
        {
            return CreateActionResult(await _services.GetWarehouseWithWareHouseInventory());
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var warehouses = await _services.GetAllAsync();
            var warehousesDtos = _mapper.Map<List<WarehouseDTO>>(warehouses.ToList());
            return CreateActionResult(CustomResponseDTO<List<WarehouseDTO>>.Success(200, warehousesDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Warehouse>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var warehouse = await _services.GetByIdAsync(id);
            var warehousesDto = _mapper.Map<WarehouseDTO>(warehouse);
            return CreateActionResult(CustomResponseDTO<WarehouseDTO>.Success(200, warehousesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(WarehouseDTO warehouseDto)
        {
            var warehouse = await _services.AddAsync(_mapper.Map<Warehouse>(warehouseDto));
            var warehousesDto = _mapper.Map<WarehouseDTO>(warehouse);
            return CreateActionResult(CustomResponseDTO<WarehouseDTO>.Success(201, warehousesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(WarehouseDTO warehouseDto)
        {
            await _services.UpdateAsync(_mapper.Map<Warehouse>(warehouseDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Warehouse>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var warehouse = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(warehouse);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
