using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.Ingredients;
using _22Percent_BE.Sevices.Products;
using AutoMapper;

namespace _22Percent_BE.Sevices
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly Lazy<IProductService> _prductService;
        private readonly Lazy<IIngredientService> _ingredientService;

        public ServiceManagement(IRepositoryManagement repositoryManagement, IMapper mapper) 
        {
            _prductService = new Lazy<IProductService>(() => new ProductService(repositoryManagement));

            _ingredientService = new Lazy<IIngredientService>(()=> new IngredientService(repositoryManagement));

        }

        public IIngredientService IngredientService => _ingredientService.Value;

        public IProductService ProductService => _prductService.Value;
    }
}
