using _22Percent_BE.Data.DTOs.Ingredients;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.IngredientRepo
{
    public interface IIngredientRepository
    {

        public Task<bool> delete(string id);
        public Task<List<Ingredient>> getAll();
        public Task<Ingredient?> getById(string id);
        public Task<List<Ingredient>> search(SearchIngredientDto search);
        public Task<bool> update(string id, UpdateIngredientDto ingredient);
        public Task<string?> UpdateList(List<UpdateIngredientDto> ingredientDtos);
        public Task create(Ingredient ingredient);


    }
}
