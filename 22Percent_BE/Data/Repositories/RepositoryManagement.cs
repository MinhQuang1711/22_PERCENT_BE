using _22Percent_BE.Data.Repositories.IngredientRepo;
using AutoMapper;

namespace _22Percent_BE.Data.Repositories
{
    public class RepositoryManagement : IRepositoryManagement
    {
        private readonly Lazy<IIngredientRepository> _lazyIngredientRepository;

        public RepositoryManagement(_22Context context,IMapper mapper) 
        {
            _lazyIngredientRepository = new Lazy<IIngredientRepository>(()=> new IngredientRepository(context,mapper));
        }

        public IIngredientRepository IngredientRepository => _lazyIngredientRepository.Value;
    }
}
