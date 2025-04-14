namespace OrderAPI.ApplicationCore.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public int Phone { get; set; }
    public string Profile_PIC { get; set; }
    public string UserId { get; set; }
    
    public ICollection<UserAddress> UserAddresses { get; set; }
    public ICollection<ShoppingCart> ShoppingCarts { get; set; }
}