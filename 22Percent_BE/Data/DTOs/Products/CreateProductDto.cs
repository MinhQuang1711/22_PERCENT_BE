using _22Percent_BE.Data.DTOs.DetailProducts;

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
}
