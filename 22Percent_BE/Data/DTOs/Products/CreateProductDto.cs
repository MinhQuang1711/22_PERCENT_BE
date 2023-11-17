using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string CreateUser { get; set; }
        public List<CreateDetailProductDto> DetailProducts { get; set; }    

        public CreateProductDto() { }
    }

    public static class CreateProductDtoEx 
    {
       public static Product ToProduct(this CreateProductDto dto,string productId)
        {
            
            var detailProducts = dto.DetailProducts.Select(e => e.ToDetailProduct(productId)).ToList();
            var product = new Product
            {
                Id = productId,
                Name = dto.Name,
                Price = dto.Price,
                Cost = GetCost(detailProducts),
                DetailProducts = detailProducts,
                Profit = dto.Price - GetCost(detailProducts),
            };
            return product; 
        }

        static double GetCost(List<DetailProduct>list) 
        {
            return list.Sum(e => e.Cost);
        }
    }
}
