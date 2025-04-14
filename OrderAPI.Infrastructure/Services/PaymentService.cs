using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    private readonly IRepository<PaymentMethod> _paymentRepository;

    public PaymentService(IRepository<PaymentMethod> paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public Task<IEnumerable<PaymentMethod>> GetAllAsync() => _paymentRepository.GetAllAsync();

    public Task<PaymentMethod?> GetByIdAsync(int id) => _paymentRepository.GetByIdAsync(id);

    public Task<int> InsertAsync(PaymentMethod method) => _paymentRepository.InsertAsync(method);

    public Task<int> UpdateAsync(PaymentMethod method) => _paymentRepository.UpdateAsync(method);

    public Task<int> DeleteAsync(int id) => _paymentRepository.DeleteAsync(id);
}
