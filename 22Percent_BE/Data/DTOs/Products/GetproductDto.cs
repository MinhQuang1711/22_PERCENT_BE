using _22percent_be.data.dtos.detailproducts;
using _22Percent_BE.Data.Entities;
using AutoMapper;

namespace _22Percent_BE.Data.DTOs.Products
{
    public class GetproductDto : BaseModel
    {

        public double Cost { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Profit { get; set; }
        public double Percent { get; set; }

        public List<GetDetailProductDto> DetailProducts { get; set; }
    }

    public static class GetProductDtoExtension 
    {
        public static GetproductDto ToGetProductDto( this Product product) 
        {
            return new GetproductDto
            {
                Id = product.Id,
                Cost = product.Cost,
                Name = product.Name,
                Price = product.Price,
                Profit = product.Profit,
                Percent = product.DetailProducts.Sum(e=> e.Cost*e.Weight/product.Price)*100,
                DetailProducts = product.DetailProducts.Select(e=> e.ToGetDetailProductDto()).ToList(),
            };
        }
    }
}
