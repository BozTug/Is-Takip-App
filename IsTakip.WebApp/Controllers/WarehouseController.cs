using AutoMapper;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTakip.WebApp.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;
        private readonly IWareHouseInventoryService _warehouseInventoryService;

        public WarehouseController(IWarehouseService warehouseService, IMapper mapper, IWareHouseInventoryService warehouseInventoryService)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
            _warehouseInventoryService = warehouseInventoryService;
        }


        // GET: WarehouseController
        public async Task<IActionResult> Index()
        {
            var warehouses = await _warehouseService.GetAllAsync();
            return View(warehouses);
        }

        // GET: WarehouseController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var warehouse = await _warehouseService.GetByIdAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            var inventory = _warehouseInventoryService.GetAllList().Where(c => c.WareHouseId == id);
            return View(warehouse);
        }

        // GET: WarehouseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WarehouseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WarehouseDTO warehouseDTO)
        {
            if (ModelState.IsValid)
            {
                await _warehouseService.AddAsync(_mapper.Map<Warehouse>(warehouseDTO));

                return RedirectToAction(nameof(Index));
            }
            
                return View();
            
        }

        // GET: WarehouseController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var warehouse = await _warehouseService.GetByIdAsync(id);
            return View(_mapper.Map<Warehouse>(warehouse));
        }

        // POST: WarehouseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(WarehouseDTO newWarehouse)
        {
            if (ModelState.IsValid)
            {
                await _warehouseService.UpdateAsync(_mapper.Map<Warehouse>(newWarehouse));

                return RedirectToAction(nameof(Index));


            }

            return View(_mapper.Map<Warehouse>(newWarehouse));
        }

        // GET: WarehouseController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var customerClass = await _warehouseService.GetByIdAsync(id);
            if (customerClass == null)
            {
                return NotFound();
            }

            await _warehouseService.DeleteAsync(customerClass);
            return RedirectToAction("Index");
        }
    }
}
