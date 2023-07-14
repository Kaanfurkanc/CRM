using AdminPortalApi.ClientServices.Interfaces;
using AdminPortalApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminPortalApi.Controllers.v1.ManagementControllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]

    public class AddressesController : ControllerBase
    {
        private readonly IClientService<AddressDTO> _clientService;

        public AddressesController(IClientService<AddressDTO> clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> AllAddressesAsync()
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Addresses");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAddressAsync(int id)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Addresses/{id}");
            var data = await response.Content.ReadAsStreamAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddressAsync(AddressDTO addressDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, "Addresses", addressDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddressAsync(int id, AddressDTO addressDTO)
        {
            var response = await _clientService.requestProcessAsync(HttpContext, $"Addresses/{id}", addressDTO);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressAsync(int id)
        {
            await _clientService.requestProcessAsync(HttpContext, $"Addresses/{id}");
            return Ok();
        }
    }
}
