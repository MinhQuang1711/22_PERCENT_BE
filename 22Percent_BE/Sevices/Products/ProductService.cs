using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManagement _repositoryManagement;

        public ProductService(IRepositoryManagement repositoryManagement) 
        {
            _repositoryManagement=repositoryManagement;
        }

        public async Task<List<GetproductDto>> GetAll()
        {
            var product= await _repositoryManagement.ProductRepository.GetAll();
            if (product == null)
            {
                return new List<GetproductDto>();   
            }
            return  product.Select(e=> e.ToGetProductDto()).ToList();

        }
    }
}
