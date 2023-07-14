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
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;
        private readonly ILogger<ClassesController> _logger;
        private readonly IMapper _mapper;

        public ClassesController(IClassService classService, ILogger<ClassesController> logger, IMapper mapper)
        {
            _classService = classService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDto>>> AllAsync()
        {
            var classes = await _classService.GetAllAsync();
            var classesDtos = _mapper.Map<List<ClassDto>>(classes.ToList());
            return Ok(classesDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDto>> ByIdAsync(int id)
        {
            var _class = await _classService.GetByIdAsync(id);
            var classDto = _mapper.Map<ClassDto>(_class);
            return Ok(classDto);
        }

        [HttpPost]
        public async Task<ActionResult> NewAsync(ClassDto classDto)
        {
            await _classService.AddAsync(_mapper.Map<Class>(classDto));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id , ClassDto classDto)
        {
            await _classService.UpdateAsync(id, _mapper.Map<Class>(classDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _classService.DeleteAsync(id);
            return Ok();
        }
    }
}
