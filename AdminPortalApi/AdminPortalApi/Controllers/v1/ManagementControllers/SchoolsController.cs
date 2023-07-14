using AdminPortalApi.ClientServices.Interfaces;
using AdminPortalApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdminPortalApi.Controllers.v1.ManagementControllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("1.1", Deprecated = true)] // Clinet can not show this version 
    public class SchoolsController : ControllerBase
    {
        private readonly IClientService<SchoolDTO> _clientService;

        public SchoolsController(IClientService<SchoolDTO> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> AllSchoolsAsync()
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Schools");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSchoolAsync(int id)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Schools/{id}");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddSchoolAsync(SchoolDTO schoolDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Schools", schoolDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchoolAsync(int id, SchoolDTO schoolDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Schools/{id}", schoolDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolAsync(int id)
        {
            await _clientService.requestProcessAsync(HttpContext, $"Schools/{id}");
            return Ok();
        }
    }
}