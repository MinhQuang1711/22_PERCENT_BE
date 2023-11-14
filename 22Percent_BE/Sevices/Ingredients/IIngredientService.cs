using _22Percent_BE.Data.DTOs.Ingredients;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Sevices.Ingredients
{
    public interface IIngredientService
    {
        public Task<bool> detete(string id);
        public Task<List<Ingredient>> getAll();
        public Task<Ingredient?> searchById(string id);
        public Task<bool> create(CreateIngredientDto create);
        public Task<string?> update(UpdateIngredientDto update);
        public Task<List<Ingredient>> searchByFilter(SearchIngredientDto search);
        public Task<string?> updateList(List<UpdateIngredientDto> dtoList);
    }
}
