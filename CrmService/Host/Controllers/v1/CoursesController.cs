using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.ServiceInterfaces;
using DomainServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("1.1", Deprecated = true)] // Clinet can not show this version 
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> AllAsync()
        {
            var courses = await _courseService.GetAllAsync();
            var coursesDto = _mapper.Map<List<CourseDto>>(courses.ToList());
            return Ok(coursesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> ByIdAsync(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            var courseDto = _mapper.Map<CourseDto>(course);
            return Ok(courseDto);
        }

        [HttpPost]
        public async Task<ActionResult> NewAsync(CourseDto courseDto)
        {
            await _courseService.AddAsync(_mapper.Map<Course>(courseDto));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, CourseDto courseDto)
        {
            await _courseService.UpdateAsync(id, _mapper.Map<Course>(courseDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _courseService.DeleteAsync(id);
            return Ok();
        }
    }
}
