using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(ILogger<UsersController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] FilterUserDTO filterUserDTO)
        {
            if (filterUserDTO.Role != null)
            {
                var usersByRole = await _userService.GetUsersByRoleAsync(filterUserDTO.Role);
                var userByRoleDTOs = _mapper.Map<List<UserResponseDTO>>(usersByRole.ToList());
                return Ok(userByRoleDTOs);
            }
            var users = await _userService.GetAllAsync();
            var userDTOs = _mapper.Map<List<UserResponseDTO>>(users.ToList());
            return Ok(userDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            var userDTO = _mapper.Map<UserResponseDTO>(user);
            return Ok(userDTO);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddNewUserAsync(NewUserDTO newUser)
        {
            await _userService.NewUserAsync(_mapper.Map<User>(newUser));
            return Ok();
                //CreatedAtAction("GetUserByIdAsync", new { id = newUser.Id }, User);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] NewUserDTO updateUser)
        {
            await _userService.UpdateUserAsync(id, _mapper.Map<User>(updateUser));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(string id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
