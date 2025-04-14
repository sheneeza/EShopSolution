using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface ICustomerService
{
    Task<IEnumerable<Address>> GetCustomerAddressesAsync(string userId);
    Task<int> SaveCustomerAddressAsync(string userId, Address address, bool isDefault);
}
