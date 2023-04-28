using AutoMapper;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsTakip.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerClassService _customerClassService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IService<CustomerRepresentative> _service;
        private readonly IService<Agenda> _agendaService;



        public CustomerController(ICustomerService customerService, ICustomerClassService customerClassService, IUserService userService, IMapper mapper, IService<CustomerRepresentative> service, IService<Agenda> agendaService)
        {
            _customerService = customerService;
            _customerClassService = customerClassService;
            _userService = userService;
            _mapper = mapper;
            _service = service;
            _agendaService = agendaService;
        }


        // GET: CustomerController
        public ActionResult Index()
        {
            var customers = _customerService.GetAllList();
            var customerClass = _customerClassService.GetAllList();
            ViewBag.CustomerClassList = customerClass.ToDictionary(c => c.Id, c => c.Description);
            var users = _userService.GetAllList();
            ViewBag.UserList = users.ToDictionary(s => s.Id, s => s.Name);
            var customerRepresentatives = _service.GetAllList();
            ViewBag.customerRepresentativesList = customerRepresentatives.ToDictionary(s => s.Id, s => s.Email);
            var customerDto = customers.Select(b => _mapper.Map<Customer>(b)).ToList();

            return View(customerDto);
        }

        // GET: CustomerController/Details/5
        public async  Task<ActionResult> Details(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            var agendas = _agendaService.GetAllList().Where(c=>c.CustomerId==id);
            var customerClass = _customerClassService.GetAllList();
            ViewBag.CustomerClassList = customerClass.ToDictionary(c => c.Id, c => c.Description);
            var users = _userService.GetAllList();
            ViewBag.UserList = users.ToDictionary(s => s.Id, s => s.Name);
            var customerRepresentatives = _service.GetAllList();
            ViewBag.customerRepresentativesList = customerRepresentatives.ToDictionary(s => s.Id, s => s.Email);
            return View(customer);
        }

        // GET: CustomerController/Create
        public async Task<IActionResult> Create()
        {
            var users = _userService.GetAllList(); 
            ViewBag.users = new SelectList(users, "Id", "Name");
            var customerClasses = _customerClassService.GetAllList();
            ViewBag.customerClasses = new SelectList(customerClasses, "Id", "Description");
            var customerRepresentatives = _service.GetAllList();
            ViewBag.customerRepresentatives = new SelectList(customerRepresentatives, "Id", "Email");
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerDTO customerDto)
        {
            if (ModelState.IsValid)
            {
                await _customerService.AddAsync(_mapper.Map<Customer>(customerDto));

                return RedirectToAction(nameof(Index));
            }
            var users = _userService.GetAllList();
            ViewBag.users = new SelectList(users, "Id", "Name");
            var customerClasses = _customerClassService.GetAllList();
            ViewBag.customerClasses = new SelectList(customerClasses, "Id", "Description");
            var customerRepresentatives = _service.GetAllList();
            ViewBag.customerRepresentatives = new SelectList(customerRepresentatives, "Id", "Email");
            return View();
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            var users = _userService.GetAllList();
            ViewBag.users = new SelectList(users, "Id", "Name");
            var customerClasses = _customerClassService.GetAllList();
            ViewBag.customerClasses = new SelectList(customerClasses, "Id", "Description");
            var customerRepresentatives = _service.GetAllList();
            ViewBag.customerRepresentatives = new SelectList(customerRepresentatives, "Id", "Email");
            return View(_mapper.Map<Customer>(customer));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerDTO newCustomer)
        {
            if (ModelState.IsValid)
            {
                await _customerService.UpdateAsync(_mapper.Map<Customer>(newCustomer));

                return RedirectToAction(nameof(Index));


            }
            var users = _userService.GetAllList();
            ViewBag.users = new SelectList(users, "Id", "Name");
            var customerClasses = _customerClassService.GetAllList();
            ViewBag.customerClasses = new SelectList(customerClasses, "Id", "Description");
            var customerRepresentatives = _service.GetAllList();
            ViewBag.customerRepresentatives = new SelectList(customerRepresentatives, "Id", "Email");
            return View(_mapper.Map<Customer>(newCustomer));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customerService.DeleteAsync(customer);
            return RedirectToAction("Index");
        }
    }
}
