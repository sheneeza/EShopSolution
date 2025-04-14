using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.Infrastructure.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Address>> GetCustomerAddressesAsync(string userId)
    {
        return await _repository.GetCustomerAddressesByUserIdAsync(userId);
    }

    public async Task<int> SaveCustomerAddressAsync(string userId, Address address, bool isDefault)
    {
        return await _repository.SaveCustomerAddressAsync(userId, address, isDefault);
    }
}