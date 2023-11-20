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

        public Task<string?> Create(CreateProductDto create, string currentUser)
        {
            var product = create.ToProduct(currentUser);
            return _repositoryManagement.ProductRepository.Create(product); 
        }

        public async Task<string?> Delete(string id)
        {
            return await _repositoryManagement.ProductRepository.Delete(id);
        }

        public async Task<List<GetproductDto>> GetAll(string currentUser)
        {
            var products= await _repositoryManagement.ProductRepository.GetAll();
            products = products.Where(e => e.CreateUser == currentUser).ToList();
            return  products.Select(e=> e.ToGetProductDto()).ToList();

        }

        public async Task<GetproductDto?> GetProductById(string id)
        {
            var product= await _repositoryManagement.ProductRepository.GetById(id);
            return product?.ToGetProductDto();
        }

        public async Task<List<GetproductDto>> SearchByFilter(SearchProductDto search, string currentUser)
        {
            var products = await _repositoryManagement.ProductRepository.SearchByFilter(search);
            products = products.Where(e => e.CreateUser == currentUser).ToList();
            return products.Select(e => e.ToGetProductDto()).ToList();
        }

        public async Task<string?> Update(UpdateProductDto dto)
        {
            var oldProduct =await _repositoryManagement.ProductRepository.GetById(dto.Id);
            if (oldProduct != null)
            {
                var product = dto.ToProduct(oldProduct);
                await _repositoryManagement.ProductRepository.Update(product);
                return null;
            }
            return Message.ProductNotExist;
        }
    }
}
