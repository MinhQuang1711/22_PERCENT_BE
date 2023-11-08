using _22Percent_BE.Data.Repositories.DetailProductRepo;
using _22Percent_BE.Data.Repositories.IngredientRepo;
using _22Percent_BE.Data.Repositories.ProductRepo;

namespace _22Percent_BE.Data.Repositories
{
    public interface IRepositoryManagement
    {
        public IProductRepository ProductRepository { get; }
        public IIngredientRepository IngredientRepository { get; }
        public IDetailProductRepository DetailProductRepository { get; }
         

    }
}
