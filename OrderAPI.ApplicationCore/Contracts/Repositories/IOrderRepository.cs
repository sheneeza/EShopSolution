using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IOrderRepository: IRepository<Order>
{
    Task<Order?> GetOrderWithDetailsAsync(int id);
}