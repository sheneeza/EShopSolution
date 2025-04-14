using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;

namespace OrderAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartItemController : ControllerBase
{
    private readonly IShoppingCartItemService _itemService;

    public ShoppingCartItemController(IShoppingCartItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpDelete("DeleteShoppingCartItemById")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        var result = await _itemService.DeleteItemByIdAsync(id);
        return result > 0 ? Ok("Item deleted from cart.") : NotFound("Item not found.");
    }
}
