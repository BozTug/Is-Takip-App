using AutoMapper;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.SupplierClass;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTakip.WebApp.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IBusinessService _businessService;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierService supplierService, IBusinessService businessService, IMapper mapper)
        {
            _supplierService = supplierService;
            _businessService = businessService;
            _mapper = mapper;
        }


        // GET: SupplierController
        public async Task<IActionResult> Index()
        {
            var supplier = await _supplierService.GetAllAsync();
            return View(supplier);
        }

        // GET: SupplierController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            var business = _businessService.GetAllList().Where(c => c.SupplierId == id);
            return View(supplier);
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SupplierDTO supplierDTO)
        {
            if (ModelState.IsValid)
            {
                await _supplierService.AddAsync(_mapper.Map<Supplier>(supplierDTO));

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: SupplierController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            return View(_mapper.Map<Supplier>(supplier));
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SupplierDTO newSupplier)
        {
            if (ModelState.IsValid)
            {
                await _supplierService.UpdateAsync(_mapper.Map<Supplier>(newSupplier));

                return RedirectToAction(nameof(Index));

            }

            return View(_mapper.Map<Supplier>(newSupplier));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _supplierService.GetByIdAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            await _supplierService.DeleteAsync(supplier);
            return RedirectToAction("Index");
        }
    }
}
