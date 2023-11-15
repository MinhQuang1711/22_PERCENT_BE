using _22Percent_BE.Data;
using _22Percent_BE.Data.Entities;

namespace _22percent_be.data.dtos.detailproducts
{
    public class GetDetailProductDto
    {
        public string IngredientName { get; set; }
        public double Weight { get; set; } 
        public double Cost { get; set; }
    }

    public static class ProductDtoExtention
    {
        public static GetDetailProductDto ToGetDetailProductDto(this DetailProduct value)
        {
            return new GetDetailProductDto
            {
                IngredientName=value.Ingredient.Name, 
                Weight = value.Weight,
                Cost = value.Cost, 
            };
        }

    
    }
}
