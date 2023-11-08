using _22percent_be.data.dtos.detailproducts;
using _22Percent_BE.Data.DTOs.Products;

namespace _22Percent_BE.Sevices.Products
{
    public interface IProductService
    {
        public Task<string?> Delete(string id); 
        public Task<List<GetproductDto>>GetAll(); 
        public Task<GetproductDto?> GetById(string id); 
        public Task<string?> CreateProduct(CreateProductDto create);
        public Task<List<GetDetailProductDto>> SearchByName(string name);
    }
}
