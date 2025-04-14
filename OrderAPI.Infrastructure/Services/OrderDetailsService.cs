using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.Infrastructure.Services;

public class OrderDetailsService: IOrderDetailsService
{
    private readonly IOrderDetailsRepository _detailsRepository;

    public OrderDetailsService(IOrderDetailsRepository detailsRepository)
    {
        _detailsRepository = detailsRepository;
    }

    public async Task<IEnumerable<Order_Details>> GetByOrderIdAsync(int orderId)
    {
        return await _detailsRepository.GetByOrderIdAsync(orderId);
    }

    public async Task<Order_Details?> GetByIdAsync(int id)
    {
        return await _detailsRepository.GetByIdAsync(id);
    }

    public async Task<int> AddDetailAsync(Order_Details detail)
    {
        return await _detailsRepository.InsertAsync(detail);
    }

    public async Task<int> UpdateDetailAsync(Order_Details detail)
    {
        return await _detailsRepository.UpdateAsync(detail);
    }

    public async Task<int> DeleteDetailAsync(int id)
    {
        return await _detailsRepository.DeleteAsync(id);
    }
}