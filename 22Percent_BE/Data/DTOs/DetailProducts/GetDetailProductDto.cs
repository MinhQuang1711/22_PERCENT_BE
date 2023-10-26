using _22Percent_BE.Data;
using _22Percent_BE.Data.Entities;

namespace _22percent_be.data.dtos.detailproducts
{
    public class GetDetailProductDto
    {
        public string IngredientName { get; set; }
        public string IngredientId {  get; set; } 
        public string ProductId { get; set; }
        public double Weight { get; set; } 
        public double Cost { get; set; }
    }

    public static class ProductDtoExtention
    {
        public static GetDetailProductDto ToGetDetailProductDto(this DetailProduct value)
        {
            return new GetDetailProductDto
            {
               
                IngredientId = value.IngredientID, 
                ProductId = value.ProductId, 
                Weight = value.Weight,
                Cost = value.Cost, 
            };
        }

    
    }
}
