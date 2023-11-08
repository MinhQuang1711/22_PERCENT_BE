using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
        public Task<Product?> GetById(string id);
        public Task<string?> Delete(string id);
        public Task<string?> Create(Product create);
        public Task<List<Product>> GetByName(string name);
       
    }
}
