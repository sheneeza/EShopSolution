using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    private readonly OrderDbContext _context;

    public CustomerRepository(OrderDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Address>> GetCustomerAddressesByUserIdAsync(string userId)
    {
        return await _context.UserAddresses
            .Include(ua => ua.Address)
            .Include(ua => ua.Customer)
            .Where(ua => ua.Customer.UserId == userId)
            .Select(ua => ua.Address)
            .ToListAsync();
    }

    public async Task<int> SaveCustomerAddressAsync(string userId, Address address, bool isDefault)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.UserId == userId);
        if (customer == null) return 0;

        // Save address
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        // Link to customer
        var userAddress = new UserAddress
        {
            Customer_Id = customer.Id,
            Address_Id = address.Id,
            IsDefaultAddress = isDefault
        };
        _context.UserAddresses.Add(userAddress);
        return await _context.SaveChangesAsync();
    }
}