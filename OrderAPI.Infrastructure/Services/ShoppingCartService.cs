using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.Infrastructure.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly IShoppingCartRepository _cartRepository;

    public ShoppingCartService(IShoppingCartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<ShoppingCart?> GetCartByCustomerIdAsync(int customerId)
    {
        return await _cartRepository.GetCartWithItemsByCustomerIdAsync(customerId);
    }

    public async Task<int> AddOrUpdateCartAsync(ShoppingCart cart)
    {
        var existing = await _cartRepository.GetCartWithItemsByCustomerIdAsync(cart.CustomerId);

        if (existing != null)
        {
            // Update existing cart
            existing.CustomerName = cart.CustomerName;
            existing.ShoppingCartItems = cart.ShoppingCartItems;
            return await _cartRepository.UpdateAsync(existing);
        }

        // Create new cart
        return await _cartRepository.InsertAsync(cart);
    }

    public async Task<int> DeleteCartAsync(int customerId)
    {
        var existing = await _cartRepository.GetCartWithItemsByCustomerIdAsync(customerId);
        return existing != null ? await _cartRepository.DeleteAsync(existing.Id) : 0;
    }
}
