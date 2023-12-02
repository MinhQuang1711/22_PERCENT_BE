using _22Percent_BE.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace _22Percent_BE.Data.DTOs.Ingredients
{
    public class CreateIngredientDto
    {
        public double? Loss { get; set; } = 0;
        public string Name { get; set; }
        public double ImportPrice { get; set; }
        public double NetWeight { get; set; }
    }

    public static class CreateIngredientDtoEx
    {
         public static Ingredient ToIngredient(this CreateIngredientDto dto, string currentUser)
        {
            var id= Guid.NewGuid().ToString();
            return new Ingredient
            {
                Id = id,
                Name = dto.Name,    
                CreateUser = currentUser,
                NetWeight = dto.NetWeight,
                RealWeight = dto.NetWeight,
                ImportPrice = dto.ImportPrice,
                Cost = (dto.ImportPrice / dto.NetWeight),
                DetailIngredient = new DetailIngredient { IngredientId= id,Weight=0,ToalCost=0 },
            };
        }
    }
}
