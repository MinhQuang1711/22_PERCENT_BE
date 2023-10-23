using _22Percent_BE.Data.Repositories.IngredientRepo;

namespace _22Percent_BE.Data.Repositories
{
    public interface IRepositoryManagement
    {
        public IIngredientRepository IngredientRepository { get; }

    }
}
