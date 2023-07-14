using AutoMapper;
using Core.DTOs;
using Core.DTOs.PaginationDTOs;
using Core.DTOs.SearchDTOs;
using Core.Entities;
using Core.ServiceInterfaces;
using Core.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("1.1", Deprecated = true)] // Clinet can not show this version 
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentsController> _logger;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, ILogger<StudentsController> logger, IMapper mapper)
        {
            _studentService = studentService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> AllAsync([FromQuery] StudentSearchDto studentSearchDto, [FromQuery] PageDto pageDto)
        {
            if (pageDto.pageNumber != null)
            {
                var students = await _studentService.GetAllAsync(pageDto.pageNumber, pageDto.pageSize);
                return Ok(students);
            }
            else
            {
                var students = await _studentService.GetAllAsync(studentSearchDto.name, studentSearchDto.studentNumber);
                var studentDtos = _mapper.Map<List<StudentDto>>(students.ToList());
                return Ok(studentDtos);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> ByIdAsync(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            var studentDto = _mapper.Map<StudentDto>(student);
            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<ActionResult> NewAsync(StudentDto studentDto)
        {
            await _studentService.AddAsync(_mapper.Map<Student>(studentDto));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, StudentDto studentDto)
        {
            await _studentService.UpdateAsync(id, _mapper.Map<Student>(studentDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _studentService.DeleteAsync(id);
            return Ok();
        }
    }
}
