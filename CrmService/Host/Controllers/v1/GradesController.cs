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
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;
        private readonly ILogger<GradesController> _logger;
        private readonly IMapper _mapper;

        public GradesController(IGradeService gradeService, ILogger<GradesController> logger, IMapper mapper)
        {
            _gradeService = gradeService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeDto>>> AllAsync()
        {
            var grades = await _gradeService.GetAllAsync();
            var gradeDtos = _mapper.Map<List<GradeDto>>(grades.ToList());
            return Ok(gradeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDto>> ByIdAsync(int id)
        {
            var grade = await _gradeService.GetByIdAsync(id);
            var gradeDto = _mapper.Map<GradeDto>(grade);
            return Ok(gradeDto);
        }

        [HttpPost]
        public async Task<ActionResult> NewAsync(GradeDto gradeDto)
        {
            await _gradeService.AddAsync(_mapper.Map<Grade>(gradeDto));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id,GradeDto gradeDto)
        {
            await _gradeService.UpdateAsync(id, _mapper.Map<Grade>(gradeDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _gradeService.DeleteAsync(id);
            return Ok();
        }
    }
}
