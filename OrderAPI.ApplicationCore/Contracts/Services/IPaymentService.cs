using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IPaymentService
{
    Task<IEnumerable<PaymentMethod>> GetAllAsync();
    Task<PaymentMethod?> GetByIdAsync(int id);
    Task<int> InsertAsync(PaymentMethod method);
    Task<int> UpdateAsync(PaymentMethod method);
    Task<int> DeleteAsync(int id);
}
