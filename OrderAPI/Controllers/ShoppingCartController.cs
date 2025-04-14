using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _cartService;
    private readonly IMapper _mapper;

    public ShoppingCartController(IShoppingCartService cartService, IMapper mapper)
    {
        _cartService = cartService;
        _mapper = mapper;
    }

    [HttpGet("GetShoppingCartByCustomerId")]
    public async Task<IActionResult> GetCartByCustomerId(int customerId)
    {
        var cart = await _cartService.GetCartByCustomerIdAsync(customerId);
        if (cart == null) return NotFound("No cart found.");
        var model = _mapper.Map<ShoppingCartModel>(cart);
        return Ok(model);
    }

    [HttpPost("SaveShoppingCart")]
    public async Task<IActionResult> SaveCart([FromBody] ShoppingCartModel model)
    {
        var entity = _mapper.Map<ShoppingCart>(model);
        var result = await _cartService.AddOrUpdateCartAsync(entity);
        return result > 0 ? Ok("Cart saved or updated.") : StatusCode(500, "Operation failed.");
    }

    [HttpDelete("DeleteShoppingCart")]
    public async Task<IActionResult> DeleteCart(int customerId)
    {
        var result = await _cartService.DeleteCartAsync(customerId);
        return result > 0 ? Ok("Cart deleted.") : NotFound("Cart not found.");
    }
}
