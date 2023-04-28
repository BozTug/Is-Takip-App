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
    public class BusinessController : CustomBaseController
    {
        private readonly IMapper _mapper;
       
        private readonly IBusinessService _services;

        public BusinessController(IMapper mapper, IBusinessService businessService)
        {
            _mapper = mapper;
           
            _services = businessService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBusinessWithCustomer()
        {
            return CreateActionResult(await _services.GetBusinessWithCustomer());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBusinessWithJobfile()
        {
            return CreateActionResult(await _services.GetBusinessWithJobfile());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBusinessWithMaterialType()
        {
            return CreateActionResult(await _services.GetBusinessWithMaterialType());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBusinessWithProductionOrder()
        {
            return CreateActionResult(await _services.GetBusinessWithProductionOrder());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBusinessWithSupplier()
        {
            return CreateActionResult(await _services.GetBusinessWithSupplier());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBusinessWithThickness()
        {
            return CreateActionResult(await _services.GetBusinessWithThickness());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var businesses = await _services.GetAllAsync();
            var businessesDtos = _mapper.Map<List<BusinessDTO>>(businesses.ToList());
            return CreateActionResult(CustomResponseDTO<List<BusinessDTO>>.Success(200, businessesDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Business>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var business = await _services.GetByIdAsync(id);
            var businessesDto = _mapper.Map<BusinessDTO>(business);
            return CreateActionResult(CustomResponseDTO<BusinessDTO>.Success(200, businessesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BusinessDTO businessDto)
        {
            var business = await _services.AddAsync(_mapper.Map<Business>(businessDto));
            var businessesDto = _mapper.Map<BusinessDTO>(business);
            return CreateActionResult(CustomResponseDTO<BusinessDTO>.Success(201, businessesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BusinessDTO businessDto)
        {
            await _services.UpdateAsync(_mapper.Map<Business>(businessDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Business>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var business = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(business);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
