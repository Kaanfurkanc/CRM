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
    public class GradesController : ControllerBase
    {
        private readonly IClientService<GradeDTO> _clientService;


        public GradesController(IClientService<GradeDTO> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> AllGradeAsync()
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Grades");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdGradeAsync(int id)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Grades/{id}");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddGradeAsync(GradeDTO gradeDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Grades", gradeDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGradeAsync(int id, GradeDTO gradeDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Grades/{id}", gradeDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGradeAsync(int id)
        {
            await _clientService.requestProcessAsync(HttpContext, $"Grades/{id}");
            return Ok();
        }
    }
}
