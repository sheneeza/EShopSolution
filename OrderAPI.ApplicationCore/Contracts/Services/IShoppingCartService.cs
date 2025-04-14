using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IShoppingCartService
{
    Task<ShoppingCart?> GetCartByCustomerIdAsync(int customerId);
    Task<int> AddOrUpdateCartAsync(ShoppingCart cart);
    Task<int> DeleteCartAsync(int customerId);
}
