namespace OrderAPI.ApplicationCore.Models;

public class ShoppingCartItemModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Qty { get; set; }
    public decimal Price { get; set; }
}

public class ShoppingCartModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public List<ShoppingCartItemModel> ShoppingCartItems { get; set; }
}
