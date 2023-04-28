using AutoMapper;
using IsTakip.API.Filters;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Agenda> _services;

        public AgendaController(IMapper mapper, IService<Agenda> services)
        {
            _mapper = mapper;
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var agendas = await _services.GetAllAsync();
            var agendasDtos = _mapper.Map<List<AgendaDTO>>(agendas.ToList());
            return CreateActionResult(CustomResponseDTO<List<AgendaDTO>>.Success(200, agendasDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Agenda>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var agenda = await _services.GetByIdAsync(id);
            var agendasDto = _mapper.Map<AgendaDTO>(agenda);
            return CreateActionResult(CustomResponseDTO<AgendaDTO>.Success(200, agendasDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(AgendaDTO agendaDto)
        {
            var agenda = await _services.AddAsync(_mapper.Map<Agenda>(agendaDto));
            var agendasDto = _mapper.Map<AgendaDTO>(agenda);
            return CreateActionResult(CustomResponseDTO<AgendaDTO>.Success(201, agendasDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(AgendaDTO agendaDto)
        {
            await _services.UpdateAsync(_mapper.Map<Agenda>(agendaDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Agenda>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var agenda = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(agenda);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
