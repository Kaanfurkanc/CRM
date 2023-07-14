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
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public AddressesController(IAddressService addressService,IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        [MapToApiVersion("1")] // Version mapping .
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDto>>> AllAsync()
        {
            var addresses = await _addressService.GetAllAsync();
            var addressDtos = _mapper.Map<List<AddressDto>>(addresses.ToList());
            return addressDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> ByIdAsync(int id)
        {
            var address = await _addressService.GetByIdAsync(id);
            var addressDto = _mapper.Map<AddressDto>(address);
            return addressDto;
        }

        [HttpPost]
        public async Task<ActionResult> NewAsync(AddressDto addressDto)
        {
            await _addressService.AddAsync(_mapper.Map<Address>(addressDto));
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id,AddressDto addressDto)
        {
            await _addressService.UpdateAsync(id, _mapper.Map<Address>(addressDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            await _addressService.DeleteAsync(id);
            return Ok();
        }
    }
}
