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
    public class ExamsController : ControllerBase
    {
        private readonly IClientService<ExamDTO> _clientService;

        public ExamsController(IClientService<ExamDTO> clientService)
        {
            _clientService = clientService;
        }


        [HttpGet]
        public async Task<IActionResult> AllExamAsync()
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Exams");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdExamAsync(int id)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Exams/{id}");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddExamAsync(ExamDTO examDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Exams", examDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExamAsync(int id, ExamDTO examDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Exams/{id}", examDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamAsync(int id)
        {
            await _clientService.requestProcessAsync(HttpContext, $"Exams/{id}");
            return Ok();
        }
    }
}
