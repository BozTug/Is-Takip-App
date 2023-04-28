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
    public class WareHouseInventoryController : CustomBaseController
    {
        private readonly IMapper _mapper;
       
        private readonly IWareHouseInventoryService _services;

        public WareHouseInventoryController(IMapper mapper,  IWareHouseInventoryService warehouseinventoryservice)
        {
            _mapper = mapper;
            
            _services = warehouseinventoryservice;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWareHouseInventoryWithWarehouse()
        {
            return CreateActionResult(await _services.GetWareHouseInventoryWithWarehouse());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWareHouseInventoryWithWareHouseShelf()
        {
            return CreateActionResult(await _services.GetWareHouseInventoryWithWareHouseShelf());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWareHouseInventoryWithMaterialType()
        {
            return CreateActionResult(await _services.GetWareHouseInventoryWithMaterialType());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWareHouseInventoryWithCustomer()
        {
            return CreateActionResult(await _services.GetWareHouseInventoryWithCustomer());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWareHouseInventoryWithSupplier()
        {
            return CreateActionResult(await _services.GetWareHouseInventoryWithSupplier());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetWareHouseInventoryWithThickness()
        {
            return CreateActionResult(await _services.GetWareHouseInventoryWithThickness());
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var wareHouseInventories = await _services.GetAllAsync();
            var wareHouseInventoriesDtos = _mapper.Map<List<WareHouseInventoryDTO>>(wareHouseInventories.ToList());
            return CreateActionResult(CustomResponseDTO<List<WareHouseInventoryDTO>>.Success(200, wareHouseInventoriesDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Core.Classes.WareHouseClasses.WareHouseInventory>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var wareHouseInventory = await _services.GetByIdAsync(id);
            var wareHouseInventoriesDto = _mapper.Map<WareHouseInventoryDTO>(wareHouseInventory);
            return CreateActionResult(CustomResponseDTO<WareHouseInventoryDTO>.Success(200, wareHouseInventoriesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(WareHouseInventoryDTO wareHouseInventoryDTO)
        {
            var wareHouseInventory = await _services.AddAsync(_mapper.Map<Core.Classes.WareHouseClasses.WareHouseInventory>(wareHouseInventoryDTO));
            var wareHouseInventoriesDto = _mapper.Map<WareHouseInventoryDTO>(wareHouseInventory);
            return CreateActionResult(CustomResponseDTO<WareHouseInventoryDTO>.Success(201, wareHouseInventoriesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(WareHouseInventoryDTO wareHouseInventoryDTO)
        {
            await _services.UpdateAsync(_mapper.Map<Core.Classes.WareHouseClasses.WareHouseInventory>(wareHouseInventoryDTO));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Core.Classes.WareHouseClasses.WareHouseInventory>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var wareHouseInventory = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(wareHouseInventory);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
