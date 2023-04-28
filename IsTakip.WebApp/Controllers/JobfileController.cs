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
    public class JobfileController : Controller
    {
        private readonly IJobfileService _jobfileService;
        private readonly IBusinessService _businessService;
        private readonly IMapper _mapper;

        public JobfileController(IJobfileService jobfileService, IBusinessService businessService, IMapper mapper)
        {
            _jobfileService = jobfileService;
            _businessService = businessService;
            _mapper = mapper;
        }



        // GET: JobfileController
        public ActionResult Index()
        {
            var jobfile = _jobfileService.GetAllList();
            var business = _businessService.GetAllList();
            ViewBag.BusinessList = business.ToDictionary(c => c.Id, c => c.CustomerOrderNo);

            return View(jobfile);
        }

        // GET: JobfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobfileController/Create
        public async Task<IActionResult> Create()
        {

            var businesses = _businessService.GetAllList();
            ViewBag.business = new SelectList(businesses, "Id", "CustomerOrderNo");
            return View();
        }

        // POST: JobfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobfileDTO jobfile)
        {
            if (ModelState.IsValid)
            {
                await _jobfileService.AddAsync(_mapper.Map<Jobfile>(jobfile));

                return RedirectToAction(nameof(Index));
            }
            var businesses = _businessService.GetAllList();
            ViewBag.business = new SelectList(businesses, "Id", "CustomerOrderNo");
            return View();
        }

        // GET: JobfileController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var jobfile = await _jobfileService.GetByIdAsync(id);
            var businesses = _businessService.GetAllList();
            ViewBag.business = new SelectList(businesses, "Id", "CustomerOrderNo");
            return View(_mapper.Map<Jobfile>(jobfile));
        }

        // POST: JobfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(JobfileDTO newJobfile)
        {
            if (ModelState.IsValid)
            {
                await _jobfileService.UpdateAsync(_mapper.Map<Jobfile>(newJobfile));
                return RedirectToAction(nameof(Index));
            }
            var businesses = _businessService.GetAllList();
            ViewBag.business = new SelectList(businesses, "Id", "CustomerOrderNo");
            return View(_mapper.Map<Jobfile>(newJobfile));
        }

        // GET: JobfileController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var jobfile = await _jobfileService.GetByIdAsync(id);
            if (jobfile == null)
            {
                return NotFound();
            }

            await _jobfileService.DeleteAsync(jobfile);
            return RedirectToAction("Index");
        }
    }
}
