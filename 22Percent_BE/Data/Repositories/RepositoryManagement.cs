using _22Percent_BE.Data.Repositories.IngredientRepo;
using _22Percent_BE.Data.Repositories.ProductRepo;
using AutoMapper;

namespace _22Percent_BE.Data.Repositories
{
    public class RepositoryManagement : IRepositoryManagement
    {
        private readonly Lazy<IProductRepository> _lazyProductRepository;
        private readonly Lazy<IIngredientRepository> _lazyIngredientRepository;

        public RepositoryManagement(_22Context context,IMapper mapper) 
        {
            _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));

            _lazyIngredientRepository = new Lazy<IIngredientRepository>(()=> new IngredientRepository(context,mapper));
            
        }

        public IProductRepository ProductRepository => _lazyProductRepository.Value;

        public IIngredientRepository IngredientRepository => _lazyIngredientRepository.Value;

       
    }
}
