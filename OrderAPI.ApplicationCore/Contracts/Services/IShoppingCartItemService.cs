namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IShoppingCartItemService
{
    Task<int> DeleteItemByIdAsync(int id);
}
