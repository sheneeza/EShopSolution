using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories;

public class OrderRepository: BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(OrderDbContext context) : base(context)
    {
    }

    public async Task<Order?> GetOrderWithDetailsAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.Order_Details)
            .FirstOrDefaultAsync(o => o.Id == id);
    }
}