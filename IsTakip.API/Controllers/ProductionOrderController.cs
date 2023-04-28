using AutoMapper;
using IsTakip.API.Filters;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionOrderController : CustomBaseController
    {
        private readonly IMapper _mapper;
      
        private readonly IProductionOrderService _services;

        public ProductionOrderController(IMapper mapper,  IProductionOrderService productionorderservice)
        {
            _mapper = mapper;
            
            _services = productionorderservice;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductionOrderWithBusiness()
        {
            return CreateActionResult(await _services.GetProductionOrderWithBusiness());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductionOrderWithProductionLead()
        {
            return CreateActionResult(await _services.GetProductionOrderWithProductionLead());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var productionOrders = await _services.GetAllAsync();
            var productionOrdersDtos = _mapper.Map<List<ProductionOrderDTO>>(productionOrders.ToList());
            return CreateActionResult(CustomResponseDTO<List<ProductionOrderDTO>>.Success(200, productionOrdersDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<ProductionOrder>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var productionOrder = await _services.GetByIdAsync(id);
            var productionOrdersDto = _mapper.Map<ProductionOrderDTO>(productionOrder);
            return CreateActionResult(CustomResponseDTO<ProductionOrderDTO>.Success(200, productionOrdersDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductionOrderDTO productionOrderDto)
        {
            var productionOrder = await _services.AddAsync(_mapper.Map<ProductionOrder>(productionOrderDto));
            var productionOrdersDto = _mapper.Map<ProductionOrderDTO>(productionOrder);
            return CreateActionResult(CustomResponseDTO<ProductionOrderDTO>.Success(201, productionOrdersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductionOrderDTO productionOrderDto)
        {
            await _services.UpdateAsync(_mapper.Map<ProductionOrder>(productionOrderDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<ProductionOrder>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var productionOrder = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(productionOrder);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
