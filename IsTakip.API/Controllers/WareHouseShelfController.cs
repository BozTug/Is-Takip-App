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
    public class WareHouseShelfController : CustomBaseController
    {
        private readonly IMapper _mapper;
       
        private readonly IWareHouseShelfService _services;

        public WareHouseShelfController(IMapper mapper,  IWareHouseShelfService wareHouseShelfService)
        {
            _mapper = mapper;
           
            _services = wareHouseShelfService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWareHouseShelfWithWarehouse()
        {
            return CreateActionResult(await _services.GetWareHouseShelfWithWarehouse());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetWareHouseShelfWithWarehouseInventory()
        {
            return CreateActionResult(await _services.GetWareHouseShelfWithWarehouseInventory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var wareHouseShelves = await _services.GetAllAsync();
            var wareHouseShelvesDtos = _mapper.Map<List<WareHouseShelfDTO>>(wareHouseShelves.ToList());
            return CreateActionResult(CustomResponseDTO<List<WareHouseShelfDTO>>.Success(200, wareHouseShelvesDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<WareHouseShelf>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var wareHouseShelf = await _services.GetByIdAsync(id);
            var wareHouseShelvesDto = _mapper.Map<WareHouseShelfDTO> (wareHouseShelf);
            return CreateActionResult(CustomResponseDTO<WareHouseShelfDTO>.Success(200, wareHouseShelvesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(WareHouseShelfDTO wareHouseShelfDto)
        {
            var wareHouseShelf = await _services.AddAsync(_mapper.Map<WareHouseShelf>(wareHouseShelfDto));
            var wareHouseShelvesDto = _mapper.Map<WareHouseShelfDTO>(wareHouseShelf);
            return CreateActionResult(CustomResponseDTO<WareHouseShelfDTO>.Success(201, wareHouseShelvesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(WareHouseShelfDTO wareHouseShelfDto)
        {
            await _services.UpdateAsync(_mapper.Map<WareHouseShelf>(wareHouseShelfDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<WareHouseShelf>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var wareHouseShelf = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(wareHouseShelf);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
