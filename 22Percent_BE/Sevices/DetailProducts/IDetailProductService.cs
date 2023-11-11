using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.DTOs.Products;

namespace _22Percent_BE.Sevices.DetailProducts
{
    public interface IDetailProductService
    {
        public Task<string?> CreateList(List<CreateDetailProductDto> create,string productId);
        public Task DeleteAysnc(string productId);
        public string? Delete(string productId);
    }
}
