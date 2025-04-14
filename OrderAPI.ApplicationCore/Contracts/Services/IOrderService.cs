using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync(int page, int size);
    Task<Order?> GetOrderByIdAsync(int id);
    Task<Order?> GetOrderWithDetailsAsync(int id);
    Task<int> InsertAsync(Order order);
    Task<int> UpdateAsync(Order order);
    Task<int> DeleteAsync(int id);
    
    Task<bool> MarkOrderCompletedAsync(int orderId);
    Task<bool> CancelOrderAsync(int orderId);
    Task<string?> GetOrderStatusAsync(int orderId);

}