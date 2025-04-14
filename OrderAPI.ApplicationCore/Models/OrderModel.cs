namespace OrderAPI.ApplicationCore.Models;

public class OrderModel
{
    public DateTime Order_Date { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int PaymentMethodId { get; set; }
    public string PaymentName { get; set; }
    public string ShippingAddress { get; set; }
    public string ShippingMethod { get; set; }
    public decimal BillAmount { get; set; }
    public string Order_Status { get; set; }
    public List<OrderDetailsModel> OrderDetails { get; set; } = new();
}