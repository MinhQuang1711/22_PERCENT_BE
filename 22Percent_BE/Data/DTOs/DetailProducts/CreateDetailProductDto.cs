using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Sevices;

namespace _22Percent_BE.Data.DTOs.DetailProducts
{
    public class CreateDetailProductDto
    {
        public double Cost { get; set; }
        public double Weight { get; set; }  
        public string IngredientId { get; set; }

        public CreateDetailProductDto() { }

       
    }
    public static class CreateDetailProductDtoExtension
    {
        public static DetailProduct ToDetailProduct(this CreateDetailProductDto dto, string productId)
        {

            return new DetailProduct
            {
                Cost = dto.Cost,
                Weight = dto.Weight,
                ProductId = productId,
                IngredientID = dto.IngredientId,
            };
        }
    }
}
