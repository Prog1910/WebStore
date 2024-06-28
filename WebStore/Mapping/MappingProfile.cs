using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.Order;
using Shared.DataTransferObjects.OrderDetails;
using Shared.DataTransferObjects.Product;

namespace WebStore.Mapping;

public class MappingProfile : Profile
{
    protected MappingProfile()
    {
        CreateMap<ProductForCreationDto, Product>();
        CreateMap<Product, ProductDto>();

        CreateMap<OrderForCreationDto, Order>();
        CreateMap<Order, OrderDto>();

        CreateMap<OrderDetailsForCreationDto, OrderDetails>();
        CreateMap<OrderDetails, OrderDetailsDto>();
    }
}