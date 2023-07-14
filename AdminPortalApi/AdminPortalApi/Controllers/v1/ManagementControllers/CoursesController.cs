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
    public class CoursesController : ControllerBase
    {
        private readonly IClientService<CourseDTO> _clientService;
        public CoursesController(IClientService<CourseDTO> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> AllCourseAsync()
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Courses");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCourseAsync(int id)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Courses/{id}");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourseAsync(CourseDTO courseDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Courses", courseDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseAsync(int id, CourseDTO courseDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Courses/{id}", courseDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseAsync(int id)
        {
            await _clientService.requestProcessAsync(HttpContext, $"Courses/{id}");
            return Ok();
        }
    }
}
