using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.DetailIngredients
{
    public class GetDetailIngredientDto: BaseModel
    {

        public double Weight { get; set; }
        public double TotalCost { get; set; }
        public string IngredientName { get; set; }

    }

    public static class GetDetailIngredientDtoEx
    {
        public static GetDetailIngredientDto ToGetDetailIngredientDto(this DetailIngredient entity)
        {
            return new GetDetailIngredientDto
            {
                Id = entity.Id,
                Weight = entity.Weight,
                TotalCost = entity.ToalCost,
                IngredientName = entity.Ingredient.Name,
            }; 
        }
    }
}
