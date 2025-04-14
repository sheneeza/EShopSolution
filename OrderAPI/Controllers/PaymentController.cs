using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;
    private readonly IMapper _mapper;

    public PaymentController(IPaymentService paymentService, IMapper mapper)
    {
        _paymentService = paymentService;
        _mapper = mapper;
    }

    [HttpGet("GetPaymentByCustomerId")] 
    public async Task<IActionResult> GetAll()
    {
        var payments = await _paymentService.GetAllAsync();
        var models = _mapper.Map<IEnumerable<PaymentMethodModel>>(payments);
        return Ok(models);
    }

    [HttpPost("SavePayment")]
    public async Task<IActionResult> Save([FromBody] PaymentMethodModel model)
    {
        var entity = _mapper.Map<PaymentMethod>(model);
        var result = await _paymentService.InsertAsync(entity);
        return result > 0 ? Ok("Payment method saved.") : StatusCode(500, "Save failed.");
    }

    [HttpPut("UpdatePayment")]
    public async Task<IActionResult> Update([FromBody] PaymentMethodModel model)
    {
        var entity = _mapper.Map<PaymentMethod>(model);
        var result = await _paymentService.UpdateAsync(entity);
        return result > 0 ? Ok("Payment method updated.") : StatusCode(500, "Update failed.");
    }

    [HttpDelete("DeletePayment")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _paymentService.DeleteAsync(id);
        return result > 0 ? Ok("Payment method deleted.") : NotFound("Payment method not found.");
    }
}
