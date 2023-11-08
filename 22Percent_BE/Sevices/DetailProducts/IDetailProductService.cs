using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.DTOs.Products;

namespace _22Percent_BE.Sevices.DetailProducts
{
    public interface IDetailProductService
    {
        public Task<string?> CreateList(List<CreateDetailProductDto> create,string productId);
    }
}
