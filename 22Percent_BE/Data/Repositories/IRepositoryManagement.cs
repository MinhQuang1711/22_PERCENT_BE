using _22Percent_BE.Data.Repositories.IngredientRepo;
using _22Percent_BE.Data.Repositories.ProductRepo;

namespace _22Percent_BE.Data.Repositories
{
    public interface IRepositoryManagement
    {
        public IIngredientRepository IngredientRepository { get; }
        public IProductRepository ProductRepository { get; }

    }
}
