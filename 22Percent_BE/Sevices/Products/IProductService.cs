using _22percent_be.data.dtos.detailproducts;
using _22Percent_BE.Data.DTOs.Products;

namespace _22Percent_BE.Sevices.Products
{
    public interface IProductService
    {
        public Task<string?> Delete(string id); 
        public Task<List<GetproductDto>>GetAll();
        public Task<string?> Update(UpdateProductDto update);
        public Task<GetproductDto?> GetById(string id);
        public Task<List<GetproductDto>> SearchByName(string name);
        public Task<string?> CreateProduct(CreateProductDto create,string productId);
       

        
    }
}
