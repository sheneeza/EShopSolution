using System.Text.Json.Serialization;

namespace OrderAPI.ApplicationCore.Entities;

public class Order_Details
{
    public int Id { get; set; }
    
    public int Order_Id { get; set; }
    [JsonIgnore]
    public Order Order { get; set; }
    
    public int Product_Id { get; set; }
    public string Product_name { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
}