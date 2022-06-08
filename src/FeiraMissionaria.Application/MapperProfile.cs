using AutoMapper;
using FeiraMissionaria.Application.Models.Product;
using FeiraMissionaria.Domain.Entities;

namespace FeiraMissionaria.Application;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<PostProductModel, Product>().ReverseMap();
        CreateMap<ProductModel, Product>().ReverseMap();
    }
}
