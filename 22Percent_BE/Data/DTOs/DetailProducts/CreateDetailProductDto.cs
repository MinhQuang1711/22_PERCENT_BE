using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;

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
        public static DetailProduct ToDetailProduct(this CreateDetailProductDto detailProduct, string productId)
        {
            return new DetailProduct
            {
                ProductId = productId,
                IngredientID = detailProduct.IngredientId,
                Weight = detailProduct.Weight

            };
        }
    }
}
