using _22Percent_BE.Data.DTOs.Products;

namespace _22Percent_BE.Sevices.Products
{
    public interface IProductService
    {
        public Task<List<GetproductDto>> GetAll();
        public Task<GetproductDto?> GetProductById(string id);
        public Task<List<GetproductDto>> SearchByFilter(SearchProductDto search); 

    }
}
