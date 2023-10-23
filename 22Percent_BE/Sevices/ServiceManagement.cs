using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.Ingredients;

namespace _22Percent_BE.Sevices
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly Lazy<IIngredientService> _ingredientService;

        public ServiceManagement(IRepositoryManagement repositoryManagement) 
        {
            _ingredientService = new Lazy<IIngredientService>(()=> new IngredientService(repositoryManagement));
        }

        public IIngredientService IngredientService => _ingredientService.Value;
    }
}
