using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories;
using AutoMapper;

namespace _22Percent_BE.Sevices.Products
{
    public class ProductService : IProductService
    {
        private readonly RepositoryManagement _repositoryManagement;
        private readonly IMapper _mapper;

        public ProductService(RepositoryManagement repositoryManagement,IMapper mapper) 
        {
            _repositoryManagement = repositoryManagement; 
            _mapper=mapper;
        } 

        public Task<string?> CreateProduct(CreateProductDto create)
        {
            var product = _mapper.Map<Product>(create);
            product.Id=Guid.NewGuid().ToString();
            product.DetailProducts= create.DetailProducts.Select(e => new DetailProduct()
            {
                Weight=e.Weight,    
                ProductId = product.Id,
                IngredientID = e.IngredientId, 
                IngredientName="",
            }).ToList() ;
            return null;
        }

        public async Task<List<GetproductDto>> GetAll()
        {
            return await _repositoryManagement.ProductRepository.getAll();
        }

        public async Task<GetproductDto> GetById(string id)
        {
            var product= await _repositoryManagement.ProductRepository.GetById(id);

            return product.ToGetProductDto();
        }
    }
}
