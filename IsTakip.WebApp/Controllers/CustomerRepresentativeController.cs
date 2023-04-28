using AutoMapper;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsTakip.WebApp.Controllers
{
    public class CustomerRepresentativeController : Controller
    {
        private readonly IService<CustomerRepresentative> _service;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerRepresentativeController(IService<CustomerRepresentative> service, ICustomerService customerService, IMapper mapper)
        {
            _service = service;
            _customerService = customerService;
            _mapper = mapper;
        }


        // GET: CustomerRepresentativeController
        public ActionResult Index()
        {
            var representative = _service.GetAllList();
            var customers = _customerService.GetAllList();
            ViewBag.CustomerList = customers.ToDictionary(c => c.Id, c => c.Description);

            return View(representative);
        }

        // GET: CustomerRepresentativeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var representative = await _service.GetByIdAsync(id);
            if (representative == null)
            {
                return NotFound();
            }
            var customer = _customerService.GetAllList().Where(c => c.CustomerRepresentativeId == id);
            return View(representative);
        }

        // GET: CustomerRepresentativeController/Create
        public async Task<IActionResult> Create()
        {
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            return View();
        }

        // POST: CustomerRepresentativeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerRepresentativeDTO customerRepresentativeDTO)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<CustomerRepresentative>(customerRepresentativeDTO));

                return RedirectToAction(nameof(Index));
            }
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            return View();
        }

        // GET: CustomerRepresentativeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var representative = await _service.GetByIdAsync(id);
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            return View(_mapper.Map<CustomerRepresentative>(representative));
        }

        // POST: CustomerRepresentativeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerRepresentativeDTO newRepresentative)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<CustomerRepresentative>(newRepresentative));
                return RedirectToAction(nameof(Index));
            }
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            return View(_mapper.Map<CustomerRepresentative>(newRepresentative));
        }

        // GET: CustomerRepresentativeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var representative = await _service.GetByIdAsync(id);
            if (representative == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(representative);
            return RedirectToAction("Index");
        }
    }
}
