using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.Ingredients;
using _22Percent_BE.Sevices.Products;
using AutoMapper;

namespace _22Percent_BE.Sevices
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly Lazy<IIngredientService> _ingredientService;
        private readonly Lazy<IProductService> _productService;

        public ServiceManagement(IRepositoryManagement repositoryManagement, IMapper mapper) 
        {
            _ingredientService = new Lazy<IIngredientService>(()=> new IngredientService(repositoryManagement));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManagement,mapper));
        }

        public IIngredientService IngredientService => _ingredientService.Value;

        public IProductService ProductService => _productService.Value;
    }
}
