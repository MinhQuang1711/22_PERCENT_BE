using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.Ingredients;

namespace _22Percent_BE.Sevices
{
    public interface IServiceManagement
    {
        public IIngredientService IngredientService { get; }
    }
}
