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
    public class SchoolsController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        private readonly IMapper _mapper;

        public SchoolsController(ISchoolService schoolService, IMapper mapper)
        {
            _schoolService = schoolService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolDto>>> AllAsync()
        {
            var schools = await _schoolService.GetAllAsync();
            var schoolDtos = _mapper.Map<List<SchoolDto>>(schools.ToList());
            return Ok(schoolDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDto>> ByIdAsync(int id)
        {
            var school = await _schoolService.GetByIdAsync(id);
            var schoolDto = _mapper.Map<SchoolDto>(school);
            return Ok(schoolDto);
        }

        [HttpPost]
        public async Task<ActionResult> NewAsync(SchoolDto schoolDto)
        {
            await _schoolService.AddAsync(_mapper.Map<School>(schoolDto));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id,SchoolDto schoolDto)
        {
            await _schoolService.UpdateAsync(id, _mapper.Map<School>(schoolDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _schoolService.DeleteAsync(id);
            return Ok();
        }
    }
}
