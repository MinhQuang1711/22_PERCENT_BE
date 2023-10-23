using _22Percent_BE.Data.DTOs.Ingredients;
using _22Percent_BE.Data.Entities;
using AutoMapper;

namespace _22Percent_BE.Helpers.Mappers
{
    public class Mapper: Profile
    {
        public Mapper() 
        {
            CreateMap<CreateIngredientDto, Ingredient>().ReverseMap();
        
        }
    }
}
