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
}
