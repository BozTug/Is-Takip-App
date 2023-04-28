using Autofac.Core;
using AutoMapper;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.SupplierClass;
using IsTakip.Core.Classes.UserClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsTakip.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, ICustomerService customerService, IMapper mapper)
        {
            _userService = userService;
            _customerService = customerService;
            _mapper = mapper;
        }


        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var users = _userService.GetAllList();
            var customer = _customerService.GetAllList();
            ViewBag.CustomerList = customer.ToDictionary(c => c.Id, c => c.Description);
            var userDto = users.Select(b => _mapper.Map<User>(b)).ToList();

            return View(userDto);
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var customers = _customerService.GetAllList();
            ViewBag.CustomerList = customers.ToDictionary(c => c.Id, c => c.Description);
            var customer = _customerService.GetAllList().Where(c => c.UserId == id);
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                await _userService.AddAsync(_mapper.Map<User>(user));

                return RedirectToAction(nameof(Index));
            }
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            return View();
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var user = await _userService.GetByIdAsync(id);
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            return View(_mapper.Map<User>(user));
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserDTO newUser)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateAsync(_mapper.Map<User>(newUser));

                return RedirectToAction(nameof(Index));

            }
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");

            return View(_mapper.Map<User>(newUser));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(user);
            return RedirectToAction("Index");
        }
    }
}
