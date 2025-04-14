namespace OrderAPI.ApplicationCore.Models;

public class OrderDetailsModel
{
    public int Product_Id { get; set; }
    public string Product_name { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}