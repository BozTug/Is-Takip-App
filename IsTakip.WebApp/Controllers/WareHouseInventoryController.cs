using Autofac.Core;
using AutoMapper;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsTakip.WebApp.Controllers
{
    public class WareHouseInventoryController : Controller
    {
        private readonly IWareHouseInventoryService _warehouseInventoryService;
        private readonly IWarehouseService _warehouseService;
        private readonly IWareHouseShelfService _warehouseShelfService;
        private readonly ICustomerService _customerService;
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;

        public WareHouseInventoryController(IWareHouseInventoryService warehouseInventoryService, IWarehouseService warehouseService, IWareHouseShelfService warehouseShelfService, ICustomerService customerService, ISupplierService supplierService, IMapper mapper)
        {
            _warehouseInventoryService = warehouseInventoryService;
            _warehouseService = warehouseService;
            _warehouseShelfService = warehouseShelfService;
            _customerService = customerService;
            _supplierService = supplierService;
            _mapper = mapper;
        }


        // GET: WareHouseInventoryController
        public ActionResult Index()
        {
            var inventories = _warehouseInventoryService.GetAllList();
            var shelf = _warehouseShelfService.GetAllList();
            ViewBag.ShelfList = shelf.ToDictionary(c => c.Id, c => c.Description);
            var warehouse = _warehouseService.GetAllList();
            ViewBag.WarehouseList = warehouse.ToDictionary(s => s.Id, s => s.Description);
            var customer = _customerService.GetAllList();
            ViewBag.CustomerList = customer.ToDictionary(c => c.Id, c => c.Description);
            var supplier = _supplierService.GetAllList();
            ViewBag.SupplierList = supplier.ToDictionary(s => s.Id, s => s.Description);
            var inventoryDto = inventories.Select(b => _mapper.Map<WareHouseInventory>(b)).ToList();

            return View(inventoryDto);
        }

        // GET: WareHouseInventoryController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var inventory = await _warehouseInventoryService.GetByIdAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            var shelf = _warehouseShelfService.GetAllList();
            ViewBag.ShelfList = shelf.ToDictionary(c => c.Id, c => c.Description);
            var warehouse = _warehouseService.GetAllList();
            ViewBag.WarehouseList = warehouse.ToDictionary(s => s.Id, s => s.Description);
            var customer = _customerService.GetAllList();
            ViewBag.CustomerList = customer.ToDictionary(c => c.Id, c => c.Description);
            var supplier = _supplierService.GetAllList();
            ViewBag.SupplierList = supplier.ToDictionary(s => s.Id, s => s.Description);
            return View(inventory);
        }

        // GET: WareHouseInventoryController/Create
        public ActionResult Create()
        {
            var shelf = _warehouseShelfService.GetAllList();
            ViewBag.shelf = new SelectList(shelf, "Id", "Description");
            var warehouse = _warehouseService.GetAllList();
            ViewBag.warehouse = new SelectList(warehouse, "Id", "Description");
            var customer = _customerService.GetAllList();
            ViewBag.customer = new SelectList(customer, "Id", "Description");
            var supplier = _supplierService.GetAllList();
            ViewBag.supplier = new SelectList(supplier, "Id", "Description");
            return View();
        }

        // POST: WareHouseInventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WareHouseInventoryDTO wareHouseInventoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _warehouseInventoryService.AddAsync(_mapper.Map<WareHouseInventory>(wareHouseInventoryDTO));

                return RedirectToAction(nameof(Index));
            }
            var shelf = _warehouseShelfService.GetAllList();
            ViewBag.shelf = new SelectList(shelf, "Id", "Description");
            var warehouse = _warehouseService.GetAllList();
            ViewBag.warehouse = new SelectList(warehouse, "Id", "Description");
            var customer = _customerService.GetAllList();
            ViewBag.customer = new SelectList(customer, "Id", "Description");
            var supplier = _supplierService.GetAllList();
            ViewBag.supplier = new SelectList(supplier, "Id", "Description");
            return View();
        }

        // GET: WareHouseInventoryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var inventory = await _warehouseInventoryService.GetByIdAsync(id);
            var shelf = _warehouseShelfService.GetAllList();
            ViewBag.shelf = new SelectList(shelf, "Id", "Description");
            var warehouse = _warehouseService.GetAllList();
            ViewBag.warehouse = new SelectList(warehouse, "Id", "Description");
            var customer = _customerService.GetAllList();
            ViewBag.customer = new SelectList(customer, "Id", "Description");
            var supplier = _supplierService.GetAllList();
            ViewBag.supplier = new SelectList(supplier, "Id", "Description");
            return View(_mapper.Map<WareHouseInventory>(inventory));
        }

        // POST: WareHouseInventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WareHouseInventoryDTO newInventory)
        {
            if (ModelState.IsValid)
            {
                await _warehouseInventoryService.UpdateAsync(_mapper.Map<WareHouseInventory>(newInventory));

                return RedirectToAction(nameof(Index));
            }
            var shelf = _warehouseShelfService.GetAllList();
            ViewBag.shelf = new SelectList(shelf, "Id", "Description");
            var warehouse = _warehouseService.GetAllList();
            ViewBag.warehouse = new SelectList(warehouse, "Id", "Description");
            var customer = _customerService.GetAllList();
            ViewBag.customer = new SelectList(customer, "Id", "Description");
            var supplier = _supplierService.GetAllList();
            ViewBag.supplier = new SelectList(supplier, "Id", "Description");
            return View(_mapper.Map<WareHouseInventory>(newInventory));
        }

        // GET: WareHouseInventoryController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var inventory = await _warehouseInventoryService.GetByIdAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            await _warehouseInventoryService.DeleteAsync(inventory);
            return RedirectToAction("Index");
        }
    }
}
