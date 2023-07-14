using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("1.1", Deprecated = true)] // Clinet can not show this version 
    public class AnnouncementsController : ControllerBase
    {

        private readonly IAnnouncementService _announcementService;
        private readonly ILogger<AnnouncementsController> _logger;
        private readonly IMapper _mapper;

        public AnnouncementsController(IAnnouncementService announcementService, ILogger<AnnouncementsController> logger ,IMapper mapper)
        {
            _announcementService = announcementService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnouncementDto>>> AllAsync()
        {
            var announcements = await _announcementService.GetAllAsync();
            var announcementDtos = _mapper.Map<List<AnnouncementDto>>(announcements.ToList());
            return Ok(announcementDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnnouncementDto>> GetByIdAsync(int id)
        {
            var announcement = await _announcementService.GetByIdAsync(id);
            var announcementDto = _mapper.Map<AnnouncementDto>(announcement);
            return Ok(announcementDto);
        }

        [HttpPost]
        public async Task<IActionResult> NewAsync(AnnouncementDto announcementDto)
        {
            await _announcementService.AddAsync(_mapper.Map<Announcement>(announcementDto));
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateAsync(int id,AnnouncementDto announcementDto)
        {
            await _announcementService.UpdateAsync(id, _mapper.Map<Announcement>(announcementDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _announcementService.DeleteAsync(id);
            return Ok();
        }
    }
}
