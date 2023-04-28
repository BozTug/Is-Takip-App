using Autofac.Core;
using AutoMapper;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsTakip.WebApp.Controllers
{
  
    public class AgendaController : Controller
    {
        private readonly IService<Agenda> _agendaService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public AgendaController(IService<Agenda> agendaService, ICustomerService customerService)
        {
            _agendaService = agendaService;
            _customerService = customerService;
        }


        // GET: Agenda
        public ActionResult Index()
        {
            var agenda = _agendaService.GetAllList();
            var customers = _customerService.GetAllList();
            ViewBag.CustomerList = customers.ToDictionary(c => c.Id, c => c.Description);           
          
            return View(agenda);
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Agenda/Create
        public async Task<IActionResult> Create()
        {
            var customers = _customerService.GetAllList();           
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            return View();
        }

        // POST: Agenda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgendaDTO agendaDto)
        {
            if (ModelState.IsValid)
            {
                await _agendaService.AddAsync(_mapper.Map<Agenda>(agendaDto));

                return RedirectToAction(nameof(Index));
            }
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");
            return View();
        }

        // GET: Agenda/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var agenda = await _agendaService.GetByIdAsync(id);
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");            
            return View(_mapper.Map<Agenda>(agenda));
        }

        // POST: Agenda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AgendaDTO newAgenda)
        {
            if (ModelState.IsValid)
            {
                await _agendaService.UpdateAsync(_mapper.Map<Agenda>(newAgenda));
                return RedirectToAction(nameof(Index));
            }
            var customers = _customerService.GetAllList();
            ViewBag.customers = new SelectList(customers, "Id", "Description");            
            return View(_mapper.Map<Agenda>(newAgenda));
        }

        // GET: Agenda/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var agenda = await _agendaService.GetByIdAsync(id);
            if (agenda == null)
            {
                return NotFound();
            }

            await _agendaService.DeleteAsync(agenda);
            return RedirectToAction("Index");
        }
    }
}
