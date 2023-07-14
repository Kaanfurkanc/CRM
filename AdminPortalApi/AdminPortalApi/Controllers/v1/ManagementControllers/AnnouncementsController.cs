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
    public class AnnouncementsController : ControllerBase
    {
        private readonly IClientService<AnnouncementDTO> _clientService;
        public AnnouncementsController(IClientService<AnnouncementDTO> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> AllAnnouncementAsync()
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Announcements");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAnnouncementAsync(int id)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Announcements/{id}");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncementAsync(AnnouncementDTO announcementDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Announcements", announcementDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnnouncementAsync(int id, AnnouncementDTO announcementDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Announcements/{id}", announcementDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncementAsync(int id)
        {
            await _clientService.requestProcessAsync(HttpContext, $"Announcements/{id}");
            return Ok();
        }
    }
}
