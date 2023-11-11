using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.Entities;
using System.Runtime.CompilerServices;

namespace _22Percent_BE.Data.DTOs.Products
{
    public class UpdateProductDto:BaseModel
    {
        public double? Price { get; set; }
        public string? ProductName { get; set; }
        public List<CreateDetailProductDto>? DeatailProduct { get; set; }
    }

    public static class UpdateProductDtoEx
    {
        public static  Product ToProduct(this UpdateProductDto dto, Product oldProduct)
        {

            if (dto.ProductName != null)
            {
                oldProduct.Name = dto.ProductName; 

            }
            if (dto.Price != null)
            {
                oldProduct.Price = (double)dto.Price;
                oldProduct.Profit = oldProduct.Price - oldProduct.Cost;
            }
            if(dto.DeatailProduct !=null && dto.DeatailProduct.Count > 0)
            {
                var detailProducts = dto.DeatailProduct.Select(e => e.ToDetailProduct(oldProduct.Id)).ToList();
                oldProduct.DetailProducts = detailProducts;
                oldProduct.Cost = GetCost(detailProducts);
                oldProduct.Profit = oldProduct.Price - oldProduct.Cost; 
                
            }
            return oldProduct; 
        }

        private static double GetCost(List<DetailProduct> list)
        {
            return list.Sum(e=> e.Cost);
        }
    }
}
