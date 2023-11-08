using _22percent_be.data.dtos.detailproducts;
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
            //TODO implement: Create detail product
            return null;
        }

        public Task<string?> Delete(string id)
        {
            throw new NotImplementedException();
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

        public Task<List<GetDetailProductDto>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
