using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
    }
}
