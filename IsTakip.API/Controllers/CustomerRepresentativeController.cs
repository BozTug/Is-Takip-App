using AutoMapper;
using IsTakip.API.Filters;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRepresentativeController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<CustomerRepresentative> _services;

        public CustomerRepresentativeController(IMapper mapper, IService<CustomerRepresentative> services)
        {
            _mapper = mapper;
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customerrepresentatives = await _services.GetAllAsync();
            var customerrepresentativesDtos = _mapper.Map<List<CustomerRepresentativeDTO>>(customerrepresentatives.ToList());
            return CreateActionResult(CustomResponseDTO<List<CustomerRepresentativeDTO>>.Success(200, customerrepresentativesDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<CustomerRepresentative>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var customerrepresentative = await _services.GetByIdAsync(id);
            var customerrepresentativesDto = _mapper.Map<CustomerRepresentativeDTO>(customerrepresentative);
            return CreateActionResult(CustomResponseDTO<CustomerRepresentativeDTO>.Success(200, customerrepresentativesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerRepresentativeDTO customerrepresentativeDto)
        {
            var customerrepresentative = await _services.AddAsync(_mapper.Map<CustomerRepresentative>(customerrepresentativeDto));
            var customerrepresentativesDto = _mapper.Map<CustomerRepresentativeDTO>(customerrepresentative);
            return CreateActionResult(CustomResponseDTO<CustomerRepresentativeDTO>.Success(201, customerrepresentativesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerRepresentativeDTO customerrepresentativeDto)
        {
            await _services.UpdateAsync(_mapper.Map<CustomerRepresentative>(customerrepresentativeDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<CustomerRepresentative>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var customerrepresentative = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(customerrepresentative);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
