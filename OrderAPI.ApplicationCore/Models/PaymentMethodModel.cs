namespace OrderAPI.ApplicationCore.Models;

public class PaymentMethodModel
{
    public int Id { get; set; }
    public int PaymentTypeId { get; set; }
    public string Provider { get; set; }
    public int AccountNumber { get; set; }
    public DateTime Expiry { get; set; }
    public bool IsDefault { get; set; }
}
