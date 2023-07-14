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
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly ILogger<TeachersController> _logger;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherService teacherService, ILogger<TeachersController> logger, IMapper mapper)
        {
            _teacherService = teacherService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> AllAsync()
        {
            var teachers = await _teacherService.GetAllAsync();
            var teacherDtos = _mapper.Map<List<TeacherDto>>(teachers.ToList());
            return Ok(teacherDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> ByIdAsync(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            var teacherDto = _mapper.Map<TeacherDto>(teacher);
            return Ok(teacherDto);
        }

        [HttpPost]
        public async Task<ActionResult> NewAsync(TeacherDto teacherDto)
        {
            await _teacherService.AddAsync(_mapper.Map<Teacher>(teacherDto));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id,TeacherDto teacherDto)
        {
            await _teacherService.UpdateAsync(id, _mapper.Map<Teacher>(teacherDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _teacherService.DeleteAsync(id);
            return Ok();
        }
    }
}
