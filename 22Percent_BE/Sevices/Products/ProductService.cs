using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
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

        public Task<string?> Create(CreateProductDto create, string productId)
        {
            var product = create.ToProduct(productId);
            return _repositoryManagement.ProductRepository.Create(product); 
        }

        public async Task<string?> Delete(string id)
        {
            return await _repositoryManagement.ProductRepository.Delete(id);
        }

        public async Task<List<GetproductDto>> GetAll()
        {
            var products= await _repositoryManagement.ProductRepository.GetAll();
            return  products.Select(e=> e.ToGetProductDto()).ToList();

        }

        public async Task<GetproductDto?> GetProductById(string id)
        {
            var product= await _repositoryManagement.ProductRepository.GetById(id);
            return product?.ToGetProductDto();
        }

        public async Task<List<GetproductDto>> SearchByFilter(SearchProductDto search)
        {
            var products = await _repositoryManagement.ProductRepository.SearchByFilter(search);
            return products.Select(e => e.ToGetProductDto()).ToList();
        }
    }
}
