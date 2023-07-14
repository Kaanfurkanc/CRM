using AdminPortalApi.ClientServices.Interfaces;
using AdminPortalApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortalApi.Controllers.v1.ManagementControllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("1.1", Deprecated = true)] // Clinet can not show this version 
    public class ClassesController : ControllerBase
    {
        private readonly IClientService<ClassDTO> _clientService;
        public ClassesController(IClientService<ClassDTO> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> AllClassAsync()
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Classes");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdClassAsync(int id)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Classes/{id}");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddClassAsync(ClassDTO classDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Classes", classDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassAsync(int id, ClassDTO classDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Classes/{id}", classDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassAsync(int id)
        {
            await _clientService.requestProcessAsync(HttpContext, $"Classes/{id}");
            return Ok();
        }
    }
}
