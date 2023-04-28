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
    public class ProductionLeadTypeController : CustomBaseController
    {
        private readonly IMapper _mapper;
       
        private readonly IProductionLeadTypeService _services;

        public ProductionLeadTypeController(IMapper mapper,  IProductionLeadTypeService leadtypeservice)
        {
            _mapper = mapper;
           
            _services = leadtypeservice;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductionLeadTypeWithProductionLead()
        {
            return CreateActionResult(await _services.GetProductionLeadTypeWithProductionLead());
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var productionLeadTypes = await _services.GetAllAsync();
            var productionLeadTypesDtos = _mapper.Map<List<ProductionLeadTypeDTO>>(productionLeadTypes.ToList());
            return CreateActionResult(CustomResponseDTO<List<ProductionLeadTypeDTO>>.Success(200, productionLeadTypesDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<ProductionLeadType>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var productionLeadType = await _services.GetByIdAsync(id);
            var productionLeadTypesDto = _mapper.Map<ProductionLeadTypeDTO>(productionLeadType);
            return CreateActionResult(CustomResponseDTO<ProductionLeadTypeDTO>.Success(200, productionLeadTypesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductionLeadTypeDTO productionleadtypeDto)
        {
            var productionLeadType = await _services.AddAsync(_mapper.Map<ProductionLeadType>(productionleadtypeDto));
            var productionLeadTypeDTOs = _mapper.Map<ProductionLeadTypeDTO>(productionLeadType);
            return CreateActionResult(CustomResponseDTO<ProductionLeadTypeDTO>.Success(201, productionLeadTypeDTOs));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductionLeadTypeDTO productionleadtypeDto)
        {
            await _services.UpdateAsync(_mapper.Map<ProductionLeadType>(productionleadtypeDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<ProductionLeadType>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var productionLeadType = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(productionLeadType);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
