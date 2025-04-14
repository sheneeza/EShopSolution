namespace OrderAPI.ApplicationCore.Entities;

public class PaymentMethod
{
    public int Id { get; set; }
    public int Payment_Type_Id { get; set; }
    public PaymentType PaymentType { get; set; }
    public string Provider { get; set; }
    public int AccountNumber { get; set; }
    public DateTime Expiry { get; set; }
    public bool isDefault { get; set; }
}