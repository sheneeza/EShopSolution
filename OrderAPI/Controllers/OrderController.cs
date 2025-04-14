using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
        
    [HttpGet("GetAllOrders")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllOrders(int page = 1, int size = 10)
    {
        var orders = await _orderService.GetAllOrdersAsync(page, size);
        return Ok(orders);
    }
    
    [HttpPost("SaveOrder")]
    //[Authorize(Roles = "Customer")]
    public async Task<IActionResult> SaveOrder([FromBody] OrderModel orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        var result = await _orderService.InsertAsync(order);
        return result > 0 ? Ok("Order placed.") : StatusCode(500, "Failed to place order.");
    }


    [HttpGet("CheckOrderHistory")]
    //[Authorize(Roles = "Customer")]
    public async Task<IActionResult> CheckOrderHistory(int customerId)
    {
        var history = await _orderService.GetOrderByIdAsync(customerId);
        return Ok(history);
    }
    
    [HttpGet("CheckOrderStatus")]
    //[Authorize(Roles = "Customer")]
    public async Task<IActionResult> CheckOrderStatus(int orderId)
    {
        var status = await _orderService.GetOrderStatusAsync(orderId);
        return status == null ? NotFound() : Ok(status);
    }

    [HttpPut("CancelOrder")]
    //[Authorize(Roles = "Customer")]
    public async Task<IActionResult> CancelOrder(int orderId)
    {
        var result = await _orderService.CancelOrderAsync(orderId);
        return result ? Ok("Order cancelled.") : BadRequest("Unable to cancel order.");
    }

    [HttpPost("OrderCompleted")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> CompleteOrder(int orderId)
    {
        var result = await _orderService.MarkOrderCompletedAsync(orderId);
        return result ? Ok("Order marked as completed.") : BadRequest("Update failed.");
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderModel updatedOrderDto)
    {
        if (updatedOrderDto == null)
            return BadRequest("Invalid order data.");

        var existingOrder = await _orderService.GetOrderByIdAsync(id);
        if (existingOrder == null)
            return NotFound("Order not found.");

        _mapper.Map(updatedOrderDto, existingOrder); 

        var result = await _orderService.UpdateAsync(existingOrder);
        return result > 0 ? Ok("Order updated.") : StatusCode(500, "Failed to update order.");
    }

}