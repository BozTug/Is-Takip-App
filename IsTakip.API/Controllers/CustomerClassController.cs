using AutoMapper;
using IsTakip.API.Filters;
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
    public class CustomerClassController : CustomBaseController
    {
        private readonly IMapper _mapper;
        
        private readonly ICustomerClassService _services;

        public CustomerClassController(IMapper mapper,  ICustomerClassService customerclassservice)
        {
            _mapper = mapper;
           
            _services = customerclassservice;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerClassWithCustomer()
        {
            return CreateActionResult(await _services.GetCustomerClassWithCustomer());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customerclasses = await _services.GetAllAsync();
            var customerclassesDtos = _mapper.Map<List<CustomerClassDTO>>(customerclasses.ToList());
            return CreateActionResult(CustomResponseDTO<List<CustomerClassDTO>>.Success(200, customerclassesDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<CustomerClass>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var customerclass = await _services.GetByIdAsync(id);
            var customerclassesDto = _mapper.Map<CustomerClassDTO>(customerclass);
            return CreateActionResult(CustomResponseDTO<CustomerClassDTO>.Success(200, customerclassesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerClassDTO customerclassDto)
        {
            var customerclass = await _services.AddAsync(_mapper.Map<CustomerClass>(customerclassDto));
            var customerclassesDto = _mapper.Map<CustomerClassDTO>(customerclass);
            return CreateActionResult(CustomResponseDTO<CustomerClassDTO>.Success(201, customerclassesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerClassDTO customerclassDto)
        {
            await _services.UpdateAsync(_mapper.Map<CustomerClass>(customerclassDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<CustomerClass>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var customerclass = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(customerclass);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
