using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        public Task Update(Product product);

        public Task<List<Product>> GetAll();

        public Task<string?> Delete(string id);

        public Task<Product?> GetById(string id);

        public Task<string?> Create(Product product);

        public Task<List<Product>> SearchByFilter(SearchProductDto search);

    }
}
