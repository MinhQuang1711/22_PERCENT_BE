using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.DetailIngredients
{
    public class UpdateDetailIngredientDto
    {
        public double Weight { get; set; }  
        public double TotalCost { get; set; }
        public string IngredentID { get; set; }
    }

    public static class UpdateDetailIngredientDtoEx
    {
        public static DetailIngredient ToDetailIngredient(this UpdateDetailIngredientDto dto)
        {
            return new DetailIngredient 
            {
                Weight = dto.Weight,
                ToalCost= dto.TotalCost,
                IngredientId= dto.IngredentID,
            };
        }
    }
}
