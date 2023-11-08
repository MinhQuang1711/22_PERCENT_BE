using _22percent_be.data.dtos.detailproducts;
using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories;
using AutoMapper;

namespace _22Percent_BE.Sevices.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManagement _repositoryManagement;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManagement repositoryManagement,IMapper mapper) 
        {
            _repositoryManagement = repositoryManagement; 
            _mapper=mapper;
        } 

        public async Task<string?> CreateProduct(CreateProductDto create)
        {
            var product = _mapper.Map<Product>(create);
            product.Id=Guid.NewGuid().ToString();
            await _repositoryManagement.ProductRepository.Create(product);
            return null;
        }

        public Task<string?> Delete(string id)
        {
            return _repositoryManagement.ProductRepository.Delete(id);
        }

        public async Task<List<GetproductDto>> GetAll()
        {
            var products= await _repositoryManagement.ProductRepository.GetAll();
            var productDtos = new List<GetproductDto>();
            foreach (var product in products)
            {
                var dto = product.ToGetProductDto();
                dto.Id = product.Id;
                productDtos.Add(dto);
            }

            return productDtos;
            
        }

        public async Task<GetproductDto?> GetById(string id)
        {
            var product= await _repositoryManagement.ProductRepository.GetById(id);

            return product?.ToGetProductDto();
        }

        public async Task<List<GetproductDto>> SearchByName(string name)
        {
            var products = await _repositoryManagement.ProductRepository.GetByName(name);
            var productDtos = new List<GetproductDto>();
            foreach (var product in products)
            {
                var dto = product.ToGetProductDto();
                dto.Id = product.Id;
                productDtos.Add(dto);
            }

            return productDtos;
        }
    }
}
