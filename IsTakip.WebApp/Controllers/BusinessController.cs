using AutoMapper;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsTakip.WebApp.Controllers
{
    public class BusinessController : Controller
    {
        private readonly IBusinessService _service;
        private readonly AppDbContext _context;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;
        public BusinessController(IBusinessService service, AppDbContext context, IMapper mapper, ICustomerService customerService, ISupplierService supplierService)
        {
            _service = service;
            _context = context;
            _mapper = mapper;
            _customerService = customerService;
            _supplierService = supplierService;
        }

        // GET: BusinessController
        public async Task<IActionResult> Index()
        {
            var businesses = _service.GetAllList();
            var customers = _customerService.GetAllList();
            ViewBag.CustomerList = customers.ToDictionary(c=>c.Id, c => c.Description);
            var suppliers = _supplierService.GetAllList();
            ViewBag.SupplierList = suppliers.ToDictionary(s=>s.Id, s => s.Description);
            var businessDtos = businesses.Select(b => _mapper.Map<Business>(b)).ToList();

            return View(businessDtos);

        }

        // GET: BusinessController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var business = await _service.GetByIdAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            var suppliers = _supplierService.GetAllList();
            ViewBag.SupplierList = suppliers.ToDictionary(s => s.Id, s => s.Description);
            var customers = _customerService.GetAllList();
            ViewBag.CustomerList = customers.ToDictionary(c => c.Id, c => c.Description);
            return View(business);
        }

        // GET: BusinessController/Create
        public async Task<IActionResult> Create()
        {
            var customers = _customerService.GetAllList(); //sadece list şeklinde veri dönen bir metod
            //List<Customer> customer = List<Customer>(customers);
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            var suppliers = _supplierService.GetAllList();
            //var supplierDto = _mapper.Map<List<SupplierDTO>>(suppliers);
            ViewBag.suppliers = new SelectList(suppliers, "Id", "Description");
            return View();
        }

        private object List<T>(Task<IEnumerable<T>> customers)
        {
            throw new NotImplementedException();
        }

        // POST: BusinessController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessDTO businessDto)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(_mapper.Map<Business>(businessDto));

                return RedirectToAction(nameof(Index));
            }
            var customers = _customerService.GetAllList(); //sadece list şeklinde veri dönen bir metod
            //List<Customer> customer = List<Customer>(customers);
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            var suppliers = _supplierService.GetAllList();
            //var supplierDto = _mapper.Map<List<SupplierDTO>>(suppliers);
            ViewBag.suppliers = new SelectList(suppliers, "Id", "Description");
            return View();
        }

        // GET: BusinessController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var business = await _service.GetByIdAsync(id);
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description", business.CustomerId);
            var suppliers = _supplierService.GetAllList();
            ViewBag.suppliers = new SelectList(suppliers, "Id", "Description", business.SupplierId);
            return View(_mapper.Map<Business>(business));
        }

        // POST: BusinessController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusinessDTO newBusiness)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Business>(newBusiness));

                return RedirectToAction(nameof(Index));
              

            }
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description", newBusiness.CustomerId);
            var suppliers = _supplierService.GetAllList();
            ViewBag.suppliers = new SelectList(suppliers, "Id", "Description", newBusiness.SupplierId);
            return View(_mapper.Map<Business>(newBusiness));
        }

        // GET: BusinessController/Delete/5
       public async Task<IActionResult> Delete(int id)
       {
                var business = await _service.GetByIdAsync(id);
                if (business == null)
                {
                    return NotFound();
                }
            
                await _service.DeleteAsync(business);
                return RedirectToAction("Index");
       }


        public IActionResult GetBusinessWithCustomer(int id)
        {
            var business = _service.GetByIdAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            var customer = _service.GetBusinessWithCustomer(id);
            ViewBag.Customer = customer;
            return View(business);

        }
    }
}
