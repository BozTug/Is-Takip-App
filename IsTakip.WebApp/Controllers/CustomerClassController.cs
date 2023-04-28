using Autofac.Core;
using AutoMapper;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Repository;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IsTakip.WebApp.Controllers
{
    public class CustomerClassController : Controller
    {
        private readonly ICustomerClassService _customerClassService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CustomerClassController(ICustomerClassService customerClassService, ICustomerService customerService, IMapper mapper, AppDbContext context)
        {
            _customerClassService = customerClassService;
            _customerService = customerService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var customerClasses = await _customerClassService.GetAllAsync();
            return View(customerClasses);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var customerClass = await _customerClassService.GetByIdAsync(id);
            if (customerClass == null)
            {
                return NotFound();
            }
            var customer = _customerService.GetAllList().Where(c=>c.CustomerClassId == id);
            return View(customerClass);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerClassDTO customerClassDTO)
        {
            if (ModelState.IsValid)
            {
                await _customerClassService.AddAsync(_mapper.Map<CustomerClass>(customerClassDTO));

                return RedirectToAction(nameof(Index));
            }
           
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customerClass = await _customerClassService.GetByIdAsync(id);           
            return View(_mapper.Map<CustomerClass>(customerClass));
        }

        // POST: BusinessController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerClassDTO newCustomerClass)
        {
            if (ModelState.IsValid)
            {
                await _customerClassService.UpdateAsync(_mapper.Map<CustomerClass>(newCustomerClass));

                return RedirectToAction(nameof(Index));


            }
           
            return View(_mapper.Map<CustomerClass>(newCustomerClass));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customerClass = await _customerClassService.GetByIdAsync(id);
            if (customerClass == null)
            {
                return NotFound();
            }

            await _customerClassService.DeleteAsync(customerClass);
            return RedirectToAction("Index");
        }

        public IActionResult GetCustumerClassWithCustomer(int id)
        {
            var business = _customerClassService.GetByIdAsync(id);
            if (business == null)
            {
                return NotFound();
            }
            var customer = _customerClassService.GetCustomerClassWithCustomer(id);
            ViewBag.Customer = customer;
            return View(business);
        }
     

    }
}

