using AutoMapper;
using SupplementStationBLL.DTO;
using SupplementStationDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplementStationBLL
{
    public class AutoMapper : Profile
    {
        public AutoMapper() 
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<NewProduct, Product>().ReverseMap();
            CreateMap<NewProductSize, ProductSize>().ReverseMap();  
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();
        }
    }
}
