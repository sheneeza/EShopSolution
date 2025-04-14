using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories;

public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
{
    public ShoppingCartRepository(OrderDbContext context) : base(context) { }

    public async Task<ShoppingCart?> GetCartWithItemsByCustomerIdAsync(int customerId)
    {
        return await _context.ShoppingCarts
            .Include(c => c.ShoppingCartItems)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }
}
