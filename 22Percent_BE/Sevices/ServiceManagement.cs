using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.DetailProducts;
using _22Percent_BE.Sevices.Ingredients;
using _22Percent_BE.Sevices.Products;
using AutoMapper;

namespace _22Percent_BE.Sevices
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly Lazy<IIngredientService> _ingredientService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IDetailProductService> _detailProductService;

        public ServiceManagement(IRepositoryManagement repositoryManagement, IMapper mapper) 
        {
            _ingredientService = new Lazy<IIngredientService>(()=> new IngredientService(repositoryManagement));

            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManagement,mapper));

            _detailProductService = new Lazy<IDetailProductService>(() => new DetailProductService(repositoryManagement));
        }

        public IIngredientService IngredientService => _ingredientService.Value;

        public IProductService ProductService => _productService.Value;

        public IDetailProductService DetailProductService => _detailProductService.Value;
    }
}
