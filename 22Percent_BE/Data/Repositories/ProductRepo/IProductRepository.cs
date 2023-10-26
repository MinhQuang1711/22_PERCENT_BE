using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.ProductRepo
{
    public interface IProductRepository
    {
      
        public Task<List<GetproductDto>> getAll();
        public Task<string?> delete(BaseModel delete);
        public Task<string?> create(CreateProductDto create);
    }
}
