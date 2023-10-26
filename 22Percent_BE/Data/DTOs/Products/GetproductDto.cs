using _22percent_be.data.dtos.detailproducts;
using _22Percent_BE.Data.Entities;
using AutoMapper;

namespace _22Percent_BE.Data.DTOs.Products
{
    public class GetproductDto : BaseModel
    {
        public double Profit { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<GetDetailProductDto> DetailProducts { get; set; }
    }

    public static class GetProductDtoExtension 
    {
        public static GetproductDto ToGetProductDto( this Product product) 
        {
            return new GetproductDto
            {
                Cost = product.Cost,
                Name = product.Name,
                Price = product.Price,
                Profit = product.Profit,
                DetailProducts = product.DetailProducts.Select(e=> e.ToGetDetailProductDto()).ToList(),
            };
        }
    }
}
