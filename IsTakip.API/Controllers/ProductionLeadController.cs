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
    public class ProductionLeadController : CustomBaseController
    {
        private readonly IMapper _mapper;
        
        private readonly IProductionLeadService _services;

        public ProductionLeadController(IMapper mapper,  IProductionLeadService productionleadservice)
        {
            _mapper = mapper;
           
            _services = productionleadservice;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductionLeadWithProductionLeadType()
        {
            return CreateActionResult(await _services.GetProductionLeadWithProductionLeadType());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductionLeadWithProductionOrder()
        {
            return CreateActionResult(await _services.GetProductionLeadWithProductionOrder());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var productionlead = await _services.GetAllAsync();
            var productionleadsDtos = _mapper.Map<List<ProductionLeadDTO>>(productionlead.ToList());
            return CreateActionResult(CustomResponseDTO<List<ProductionLeadDTO>>.Success(200, productionleadsDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<ProductionLead>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var productionlead = await _services.GetByIdAsync(id);
            var productionleadsDto = _mapper.Map<ProductionLeadDTO>(productionlead);
            return CreateActionResult(CustomResponseDTO<ProductionLeadDTO>.Success(200, productionleadsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductionLeadDTO productionleadDto)
        {
            var productionlead = await _services.AddAsync(_mapper.Map<ProductionLead>(productionleadDto));
            var productionleadsDto = _mapper.Map<ProductionLeadDTO>(productionlead);
            return CreateActionResult(CustomResponseDTO<ProductionLeadDTO>.Success(201, productionleadsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductionLeadDTO productionleadDto)
        {
            await _services.UpdateAsync(_mapper.Map<ProductionLead>(productionleadDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<ProductionLead>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var productionlead = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(productionlead);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
