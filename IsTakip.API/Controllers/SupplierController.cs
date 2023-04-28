using AutoMapper;
using IsTakip.API.Filters;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.SupplierClass;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : CustomBaseController
    {
        private readonly IMapper _mapper;
        
        private readonly ISupplierService _services;

        public SupplierController(IMapper mapper, ISupplierService supplierService)
        {
            _mapper = mapper;
          
            _services = supplierService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSupplierWithBusiness()
        {
            return CreateActionResult(await _services.GetSupplierWithBusiness());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetSupplierWithWareHouseInventory()
        {
            return CreateActionResult(await _services.GetSupplierWithWareHouseInventory());
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var suppliers = await _services.GetAllAsync();
            var suppliersDtos = _mapper.Map<List<SupplierDTO>>(suppliers.ToList());
            return CreateActionResult(CustomResponseDTO<List<SupplierDTO>>.Success(200, suppliersDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Supplier>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var supplier = await _services.GetByIdAsync(id);
            var suppliersDto = _mapper.Map<SupplierDTO>(supplier);
            return CreateActionResult(CustomResponseDTO<SupplierDTO>.Success(200, suppliersDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SupplierDTO supplierDto)
        {
            var supplier = await _services.AddAsync(_mapper.Map<Supplier>(supplierDto));
            var suppliersDto = _mapper.Map<SupplierDTO>(supplier);
            return CreateActionResult(CustomResponseDTO<SupplierDTO>.Success(201, suppliersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(SupplierDTO supplierDto)
        {
            await _services.UpdateAsync(_mapper.Map<Supplier>(supplierDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Supplier>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var supplier = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(supplier);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
