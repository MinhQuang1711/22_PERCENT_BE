using _22Percent_BE.Data.Repositories.IngredientRepo;

namespace _22Percent_BE.Data.Repositories
{
    public interface IManagementRepository
    {
        public IIngredientRepository IngredientRepository { get; }

    }
}
