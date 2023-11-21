using _22Percent_BE.Data.DTOs.DetailIngredients;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.Inventories
{
    public class GetInventoryDto
    {
        public double TotalIngredientPrice { get; set; }
        public List<GetDetailIngredientDto> DetailIngredients { get; set; }
    }
    public static class GetInventoryDtoEx
    {
        public static GetInventoryDto ToGetInventoryDto(this Inventory entity)
        {
            return new GetInventoryDto 
            {
                TotalIngredientPrice= entity.DetailIngredients.Sum(e=> e.ToalCost), 
                DetailIngredients= entity.DetailIngredients.Select(e=> e.ToGetDetailIngredientDto()).ToList(),  
            };
        }
    }
}
