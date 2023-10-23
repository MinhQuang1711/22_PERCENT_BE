using System.ComponentModel.DataAnnotations;

namespace _22Percent_BE.Data.DTOs.Ingredients
{
    public class CreateIngredientDto
    {
        public double? Loss { get; set; } = 0;
        public string Name { get; set; }
        public double Price { get; set; }
        public double NetWight { get; set; }

    }
}
