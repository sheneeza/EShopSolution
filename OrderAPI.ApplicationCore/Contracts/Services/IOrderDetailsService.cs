using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IOrderDetailsService
{
    Task<IEnumerable<Order_Details>> GetByOrderIdAsync(int orderId);
    Task<Order_Details?> GetByIdAsync(int id);
    Task<int> AddDetailAsync(Order_Details detail);
    Task<int> UpdateDetailAsync(Order_Details detail);
    Task<int> DeleteDetailAsync(int id);
}