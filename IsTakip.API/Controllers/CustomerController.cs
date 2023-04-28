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
    public class CustomerController : CustomBaseController
    {
        private readonly IMapper _mapper;
       
        private readonly ICustomerService _services;

        public CustomerController(IMapper mapper,  ICustomerService customerService)
        {
            _mapper = mapper;
          
            _services = customerService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerWithCustomerClass()
        {
            return CreateActionResult(await _services.GetCustomerWithCustomerClass());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerWithAgenda()
        {
            return CreateActionResult(await _services.GetCustomerWithAgenda());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerWithBusiness()
        {
            return CreateActionResult(await _services.GetCustomerWithBusiness());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerWithCustomerRepresentative()
        {
            return CreateActionResult(await _services.GetCustomerWithCustomerRepresentative());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerWithCustomerRestriction()
        {
            return CreateActionResult(await _services.GetCustomerWithCustomerRestriction());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerWithWareHouseInventory()
        {
            return CreateActionResult(await _services.GetCustomerWithWareHouseInventory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customers = await _services.GetAllAsync();
            var customersDtos = _mapper.Map<List<CustomerDTO>>(customers.ToList());
            return CreateActionResult(CustomResponseDTO<List<CustomerDTO>>.Success(200, customersDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _services.GetByIdAsync(id);
            var customersDto = _mapper.Map<CustomerDTO>(customer);
            return CreateActionResult(CustomResponseDTO<CustomerDTO>.Success(200, customersDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDTO customerDto)
        {
            var customer = await _services.AddAsync(_mapper.Map<Customer>(customerDto));
            var customersDto = _mapper.Map<CustomerDTO>(customer);
            return CreateActionResult(CustomResponseDTO<CustomerDTO>.Success(201, customersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CustomerDTO customerDto)
        {
            await _services.UpdateAsync(_mapper.Map<Customer>(customerDto));        
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(customer);          
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
