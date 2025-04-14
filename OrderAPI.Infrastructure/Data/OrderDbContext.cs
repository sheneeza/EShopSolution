using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.Infrastructure.Data;

public class OrderDbContext: DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Order> Orders { get; set; }
    public DbSet<Order_Details> Order_Details { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }

}