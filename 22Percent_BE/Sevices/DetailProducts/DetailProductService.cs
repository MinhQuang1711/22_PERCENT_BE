using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.DetailProducts
{
    public class DetailProductService : IDetailProductService
    {
        private readonly IRepositoryManagement _repositoryManagement;

        public DetailProductService(IRepositoryManagement repositoryManagement) 
        {
            _repositoryManagement=repositoryManagement;
        }   

        public async Task<string?> CreateList(List<CreateDetailProductDto> create,string productId)
        {
            var detailProducts= create.Select(e=> e.ToDetailProduct(productId)).ToList();
            return await _repositoryManagement.DetailProductRepository.CreateList(detailProducts);
        }
    }
}
