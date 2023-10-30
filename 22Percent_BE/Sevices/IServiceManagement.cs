using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.Ingredients;
using _22Percent_BE.Sevices.Products;

namespace _22Percent_BE.Sevices
{
    public interface IServiceManagement
    {
        public IIngredientService IngredientService { get; }
        public IProductService ProductService { get; }
    }
}
