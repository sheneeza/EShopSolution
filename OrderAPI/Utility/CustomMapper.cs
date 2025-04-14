using AutoMapper;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Models;

namespace OrderAPI.Utility;

public class CustomMapper: Profile
{
    public CustomMapper()
    {
        CreateMap<OrderModel, Order>().ReverseMap();
        CreateMap<OrderDetailsModel, Order_Details>().ReverseMap();
        CreateMap<SaveAddressRequest, Address>().ReverseMap();
        CreateMap<PaymentMethodModel, PaymentMethod>().ReverseMap();
        CreateMap<ShoppingCartItemModel, ShoppingCartItem>().ReverseMap();
        CreateMap<ShoppingCartModel, ShoppingCart>().ReverseMap();
    }
}