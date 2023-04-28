using AutoMapper;
using IsTakip.API.Filters;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobfileController : CustomBaseController
    {
        private readonly IMapper _mapper;
      
        private readonly IJobfileService _services;

        public JobfileController(IMapper mapper,  IJobfileService jobfileService)
        {
            _mapper = mapper;
            
            _services = jobfileService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetJobfileWithBusiness()
        {
            return CreateActionResult(await _services.GetJobfileWithBusiness());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var jobfiles = await _services.GetAllAsync();
            var jobfileDtos = _mapper.Map<List<JobfileDTO>>(jobfiles.ToList());
            return CreateActionResult(CustomResponseDTO<List<JobfileDTO>>.Success(200, jobfileDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Jobfile>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var jobfile = await _services.GetByIdAsync(id);
            var jobfileDto = _mapper.Map<JobfileDTO>(jobfile);
            return CreateActionResult(CustomResponseDTO<JobfileDTO>.Success(200, jobfileDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(JobfileDTO jobfileDto)
        {
            var jobfile = await _services.AddAsync(_mapper.Map<Jobfile>(jobfileDto));
            var jobfilesDto = _mapper.Map<JobfileDTO>(jobfileDto);
            return CreateActionResult(CustomResponseDTO<JobfileDTO>.Success(201, jobfilesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(JobfileDTO jobfileDto)
        {
            await _services.UpdateAsync(_mapper.Map<Jobfile>(jobfileDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Jobfile>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var jobfile = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(jobfile);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
