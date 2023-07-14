using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.LoginManagerInterfaces;
using Core.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Host.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class AccountsController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly ILoginManager _loginManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AccountsController(IOptions<JwtSettings> jwtSettings, ILoginManager loginManager, IUserService userService, IMapper mapper)
        {
            _jwtSettings = jwtSettings.Value;
            _loginManager = loginManager;
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous] //not include authorize
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            var user = await _userService.GetUserByUsernameAsync(loginDTO.UserName!);
            if (user == null) { return NotFound("User could not found "); }

            if (_loginManager.Verification(user,loginDTO))
            {
                var token = _loginManager.CreateToken(_mapper.Map<UserResponseDTO>(user));
                return Ok(token);
            }
            return Forbid();
        }
    }
}