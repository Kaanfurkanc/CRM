using Core.Entities;
using DomainServices;
using Core.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Core.DTOs;

namespace Host.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1")]
    [ApiVersion("1.1", Deprecated = true)] // Clinet can not show this version 
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IMapper _mapper;

        public ExamsController(IExamService examService, IMapper mapper)
        {
            _examService = examService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamDto>>> AllAsync()
        {
            var exams = await _examService.GetAllAsync();
            var examDtos = _mapper.Map<List<ExamDto>>(exams.ToList());
            return Ok(examDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamDto>> ByIdAsync(int id)
        {
            var exam = await _examService.GetByIdAsync(id);
            var examDto = _mapper.Map<ExamDto>(exam);
            return Ok(examDto);
        }

        [HttpPost]
        public async Task<ActionResult> NewAsync(ExamDto examDto)
        {
            await _examService.AddAsync(_mapper.Map<Exam>(examDto));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, ExamDto examDto)
        {
            await _examService.UpdateAsync(id, _mapper.Map<Exam>(examDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _examService.DeleteAsync(id);
            return Ok();
        }

    }
}
