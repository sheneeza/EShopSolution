using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Services;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly OrderDbContext _context;

    public OrderService(IOrderRepository orderRepository, OrderDbContext context)
    {
        _orderRepository = orderRepository;
        _context = context;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync(int page, int size)
    {
        return await _context.Orders
            .Include(o => o.Order_Details)
            .OrderByDescending(o => o.Order_Date)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }


    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task<Order?> GetOrderWithDetailsAsync(int id)
    {
        return await _orderRepository.GetOrderWithDetailsAsync(id);
    }

    public async Task<int> InsertAsync(Order order)
    {
        return await _orderRepository.InsertAsync(order);
    }

    public async Task<int> UpdateAsync(Order order)
    {
        return await _orderRepository.UpdateAsync(order);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _orderRepository.DeleteAsync(id);
    }
    
    public async Task<bool> MarkOrderCompletedAsync(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order == null) return false;

        order.Order_Status = "Completed";
        _context.Orders.Update(order);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> CancelOrderAsync(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order == null || order.Order_Status == "Completed") return false;

        order.Order_Status = "Cancelled";
        _context.Orders.Update(order);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<string?> GetOrderStatusAsync(int orderId)
    {
        var order = await _context.Orders.FindAsync(orderId);
        return order?.Order_Status;
    }

}