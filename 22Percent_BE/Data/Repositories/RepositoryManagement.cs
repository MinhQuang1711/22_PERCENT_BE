using _22Percent_BE.Data.Repositories.IngredientRepo;
using _22Percent_BE.Data.Repositories.ProductRepo;
using AutoMapper;

namespace _22Percent_BE.Data.Repositories
{
    public class RepositoryManagement : IRepositoryManagement
    {
        private readonly Lazy<IIngredientRepository> _lazyIngredientRepository;
        private readonly Lazy<IProductRepository> _lazyProductRepository;

        public RepositoryManagement(_22Context context,IMapper mapper) 
        {
            _lazyIngredientRepository = new Lazy<IIngredientRepository>(()=> new IngredientRepository(context,mapper));
            _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(context, mapper));
        }

        public IIngredientRepository IngredientRepository => _lazyIngredientRepository.Value;

        public IProductRepository ProductRepository => _lazyProductRepository.Value;
    }
}
