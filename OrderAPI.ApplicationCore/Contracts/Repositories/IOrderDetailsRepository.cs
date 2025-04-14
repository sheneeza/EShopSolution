using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IOrderDetailsRepository: IRepository<Order_Details>
{
    Task<IEnumerable<Order_Details>> GetByOrderIdAsync(int orderId);
}