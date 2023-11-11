using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.DetailProducts;
using _22Percent_BE.Sevices.Ingredients;
using _22Percent_BE.Sevices.Products;
using AutoMapper;

namespace _22Percent_BE.Sevices
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly Lazy<IProductService> _prductService;
        private readonly Lazy<IIngredientService> _ingredientService;
        private readonly Lazy<IDetailProductService> _detailProductService;

        public ServiceManagement(IRepositoryManagement repositoryManagement, IMapper mapper) 
        {
            _prductService = new Lazy<IProductService>(() => new ProductService(repositoryManagement));

            _ingredientService = new Lazy<IIngredientService>(()=> new IngredientService(repositoryManagement));


            _detailProductService = new Lazy<IDetailProductService>(() => new DetailProductService(repositoryManagement));
        }

        public IIngredientService IngredientService => _ingredientService.Value;

        public IDetailProductService DetailProductService => _detailProductService.Value;

        public IProductService ProductService => _prductService.Value;
    }
}
