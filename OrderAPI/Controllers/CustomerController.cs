using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }
    
    [HttpGet("GetCustomerAddressByUserId")]
    public async Task<IActionResult> GetCustomerAddressByUserId([FromQuery] string userId)
    {
        var addresses = await _customerService.GetCustomerAddressesAsync(userId);
        return Ok(addresses);
    }

    [HttpPost("SaveCustomerAddress")]
    public async Task<IActionResult> SaveCustomerAddress([FromBody] SaveAddressRequest request)
    {
        var address = _mapper.Map<Address>(request);

        var result = await _customerService.SaveCustomerAddressAsync(
            request.UserId,
            address,
            request.IsDefaultAddress
        );

        return result > 0 ? Ok("Address saved successfully") : BadRequest("Failed to save address");
    }
}
