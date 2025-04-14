namespace OrderAPI.ApplicationCore.Entities;

public class ShoppingCart
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    
    public Customer Customer { get; set; }
    public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
}