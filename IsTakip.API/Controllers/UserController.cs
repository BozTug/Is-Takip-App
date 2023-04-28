using AutoMapper;
using IsTakip.API.Filters;
using IsTakip.Core.Classes.CustomerClasses;
using IsTakip.Core.Classes.UserClasses;
using IsTakip.Core.DTOs;
using IsTakip.Core.Services;
using IsTakip.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IMapper _mapper;
       
        private readonly IUserService _services;

        public UserController(IMapper mapper,  IUserService userService)
        {
            _mapper = mapper;
          
            _services = userService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserWithCustomer()
        {
            return CreateActionResult(await _services.GetUserWithCustomer());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _services.GetAllAsync();
            var usersDtos = _mapper.Map<List<UserDTO>>(users.ToList());
            return CreateActionResult(CustomResponseDTO<List<UserDTO>>.Success(200, usersDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _services.GetByIdAsync(id);
            var usersDto = _mapper.Map<UserDTO>(user);
            return CreateActionResult(CustomResponseDTO<UserDTO>.Success(200, usersDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDTO userDto)
        {
            var user = await _services.AddAsync(_mapper.Map<User>(userDto));
            var usersDto = _mapper.Map<UserDTO>(user);
            return CreateActionResult(CustomResponseDTO<UserDTO>.Success(201, usersDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDTO userDto)
        {
            await _services.UpdateAsync(_mapper.Map<User>(userDto));
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _services.GetByIdAsync(id);
            await _services.DeleteAsync(user);
            return CreateActionResult(CustomResponseDTO<List<NoContentDTO>>.Success(204));
        }
    }
}
