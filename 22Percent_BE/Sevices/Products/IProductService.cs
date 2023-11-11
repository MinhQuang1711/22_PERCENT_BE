using _22Percent_BE.Data.DTOs.Products;

namespace _22Percent_BE.Sevices.Products
{
    public interface IProductService
    {

        public Task<string?> Delete(string id);

        public Task<List<GetproductDto>> GetAll();

        public Task<string?> Update(UpdateProductDto dto);

        public Task<GetproductDto?> GetProductById(string id);

        public Task<string?> Create(CreateProductDto create, string productId);

        public Task<List<GetproductDto>> SearchByFilter(SearchProductDto search); 

    }
}
