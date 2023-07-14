using AdminPortalApi.ClientServices.Interfaces;
using AdminPortalApi.DTOs;
using AdminPortalApi.DTOs.PaginationDTOs;
using AdminPortalApi.DTOs.SearchDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortalApi.Controllers.v1.ManagementControllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("1.1", Deprecated = true)] // Client can not show this version 
    public class StudentsController : ControllerBase
    {
        private readonly IClientService<StudentDTO> _clientService;

        public StudentsController(IClientService<StudentDTO> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> AllStudentAsync([FromQuery] StudentSearchDTO studentSearchDto, [FromQuery] PageDTO pageDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Students");
            if (studentSearchDto.name != null)
            {
                response = await _clientService.requestProcessAsync(HttpContext, $"Students?name={studentSearchDto.name}");
            }
            else if (studentSearchDto.studentNumber != null)
            {
                response = await _clientService.requestProcessAsync(HttpContext, $"Students?studentNumber={studentSearchDto.studentNumber}");

            }
            else if (pageDTO.pageNumber != null)
            {
                response = await _clientService.requestProcessAsync(HttpContext, $"Students?pageNumber={pageDTO.pageNumber}&pageSize={pageDTO.pageSize}");
            }
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdStudentAsync(int id)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Students/{id}");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(StudentDTO studentDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Students", studentDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentAsync(int id, StudentDTO studentDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Students/{id}", studentDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            await _clientService.requestProcessAsync(HttpContext, $"Students/{id}");
            return Ok();
        }
    }
}
