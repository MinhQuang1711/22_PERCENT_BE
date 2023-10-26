using _22percent_be.data.dtos.detailproducts;
using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.DTOs.Ingredients;
using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
using AutoMapper;

namespace _22Percent_BE.Helpers.Mappers
{
    public class Mapper: Profile
    {
        public Mapper() 
        {
            CreateMap<GetDetailProductDto,DetailProduct>().ReverseMap();
            CreateMap<GetproductDto,Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<CreateIngredientDto, Ingredient>().ReverseMap();
            CreateMap<CreateDetailProductDto,DetailProduct>().ReverseMap();
            
        
        }
    }
}
