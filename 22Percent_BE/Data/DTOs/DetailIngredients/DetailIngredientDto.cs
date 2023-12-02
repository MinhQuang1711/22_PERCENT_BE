using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.DetailIngredients
{
    public class DetailIngredientDto
    {
        public double Weight { get; set; }  
        public double TotalCost { get; set; }
        public string IngredentID { get; set; }
    }
}
