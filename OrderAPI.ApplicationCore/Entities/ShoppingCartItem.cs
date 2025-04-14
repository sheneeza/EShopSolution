namespace OrderAPI.ApplicationCore.Entities;

public class ShoppingCartItem
{
    public int Id { get; set; }
    public int Cart_Id { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public int ProductId { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
    public string ProductName { get; set; }
}