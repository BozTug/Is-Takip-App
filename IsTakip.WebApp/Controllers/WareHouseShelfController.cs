using AutoMapper;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace IsTakip.WebApp.Controllers
{
    public class WareHouseShelfController : Controller
    {
        private readonly IWareHouseShelfService _warehouseShelfService;
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;

        public WareHouseShelfController(IWareHouseShelfService warehouseShelfService, IWarehouseService warehouseService, IMapper mapper)
        {
            _warehouseShelfService = warehouseShelfService;
            _warehouseService = warehouseService;
            _mapper = mapper;
        }


        // GET: WareHouseShelfController
        public ActionResult Index()
        {
            var wareHouseShelves = _warehouseShelfService.GetAllList();
            var warehouse = _warehouseService.GetAllList();
            ViewBag.WarehouseList = warehouse.ToDictionary(c => c.Id, c => c.Description);

            return View(wareHouseShelves);
        }

        // GET: WareHouseShelfController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WareHouseShelfController/Create
        public async Task<IActionResult> Create()
        {
            var warehouse = _warehouseService.GetAllList();
            ViewBag.warehouse = new SelectList(warehouse, "Id", "Description");
            return View();
        }

        // POST: WareHouseShelfController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WareHouseShelfDTO wareHouseShelfDTO)
        {
            if (ModelState.IsValid)
            {
                await _warehouseShelfService.AddAsync(_mapper.Map<WareHouseShelf>(wareHouseShelfDTO));

                return RedirectToAction(nameof(Index));
            }
            var warehouse = _warehouseService.GetAllList();
            ViewBag.warehouse = new SelectList(warehouse, "Id", "Description");
            return View();
        }

        // GET: WareHouseShelfController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var warehouseShelf = await _warehouseShelfService.GetByIdAsync(id);
            var warehouse = _warehouseService.GetAllList();
            ViewBag.warehouse = new SelectList(warehouse, "Id", "Description");
            return View(_mapper.Map<WareHouseShelf>(warehouseShelf));
        }

        // POST: WareHouseShelfController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WareHouseShelfDTO newShelf)
        {
            if (ModelState.IsValid)
            {
                await _warehouseShelfService.UpdateAsync(_mapper.Map<WareHouseShelf>(newShelf));
                return RedirectToAction(nameof(Index));
            }
            var warehouse = _warehouseService.GetAllList();
            ViewBag.warehouse = new SelectList(warehouse, "Id", "Description");
            return View(_mapper.Map<WareHouseShelf>(newShelf));
        }

        // GET: WareHouseShelfController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var shelf = await _warehouseShelfService.GetByIdAsync(id);
            if (shelf == null)
            {
                return NotFound();
            }

            await _warehouseShelfService.DeleteAsync(shelf);
            return RedirectToAction("Index");
        }
    }
}
