using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<IEnumerable<Address>> GetCustomerAddressesByUserIdAsync(string userId);
    Task<int> SaveCustomerAddressAsync(string userId, Address address, bool isDefault);
}
