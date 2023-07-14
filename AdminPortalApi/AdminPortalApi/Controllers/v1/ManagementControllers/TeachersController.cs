using AdminPortalApi.ClientServices.Interfaces;
using AdminPortalApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AdminPortalApi.Controllers.v1.ManagementControllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("1.1", Deprecated = true)] // Clinet can not show this version 
    public class TeachersController : ControllerBase
    {
        private readonly IClientService<TeacherDTO> _clientService;
        public TeachersController(IClientService<TeacherDTO> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> AllTeacherAsync()
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Teachers");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTeacherAsync(int id)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Teachers/{id}");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacherAsync(TeacherDTO teacherDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Teachers", teacherDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacherAsync(int id, TeacherDTO teacherDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Teachers/{id}", teacherDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacherAsync(int id)
        {
            await _clientService.requestProcessAsync(HttpContext, $"Teachers/{id}");
            return Ok();
        }
    }
}
