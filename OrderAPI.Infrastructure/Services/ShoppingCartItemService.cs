using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.Infrastructure.Services;

public class ShoppingCartItemService : IShoppingCartItemService
{
    private readonly IRepository<ShoppingCartItem> _itemRepository;

    public ShoppingCartItemService(IRepository<ShoppingCartItem> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<int> DeleteItemByIdAsync(int id)
    {
        return await _itemRepository.DeleteAsync(id);
    }
}
