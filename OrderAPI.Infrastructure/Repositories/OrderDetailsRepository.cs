using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories;

public class OrderDetailsRepository: BaseRepository<Order_Details>, IOrderDetailsRepository
{
    public OrderDetailsRepository(OrderDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order_Details>> GetByOrderIdAsync(int orderId)
    {
        return await _context.Order_Details
            .Where(od => od.Order_Id == orderId)
            .ToListAsync();
    }
}