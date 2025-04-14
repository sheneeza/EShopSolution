namespace OrderAPI.ApplicationCore.Models;

public class SaveAddressRequest
{
    public string UserId { get; set; }
    public string City { get; set; }
    public string Street1 { get; set; }
    public string? Street2 { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public bool IsDefaultAddress { get; set; }
}
