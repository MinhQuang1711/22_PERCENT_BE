using _22Percent_BE.Data.DTOs.Products;

namespace _22Percent_BE.Data.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        public Task<bool> create(CreateProductDto create);
    }
}
