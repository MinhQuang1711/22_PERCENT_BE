using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.DTOs.Products;

namespace _22Percent_BE.Sevices.DetailProducts
{
    public interface IDetailProductService
    {
        public Task CreateList(List<CreateDetailProductDto> create,string productId);
        public Task Delete(string productId);
    }
}
