using _22Percent_BE.Data.DTOs.Ingredients;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.Ingredients
{
    public class IngredientService : IIngredientService
    {
        private readonly IManagementRepository _managementRepository;

        public IngredientService(IManagementRepository managementRepository) 
        {
            _managementRepository= managementRepository;
        }

        public async Task<bool> create(CreateIngredientDto create)
        {
            return await _managementRepository.IngredientRepository.create(create);
        }

        public async Task<bool> detete(string id)
        {
            return await _managementRepository.IngredientRepository.delete(id);
        }

        public async Task<List<Ingredient>> getAll()
        {
            return await _managementRepository.IngredientRepository.getAll();
        }

        public async Task<List<Ingredient>> searchByFilter(SearchIngredientDto search)
        {
            return await _managementRepository.IngredientRepository.search(search); 
        }

        public async Task<Ingredient?> searchById(string id)
        {
            return await _managementRepository.IngredientRepository.getById(id);
        }

        public async Task<string?> update( string id, UpdateIngredientDto update)
        {
            var result = await _managementRepository.IngredientRepository.update(id,update);
            if (result == false)
            {
                return "Nguyên liệu không tồn tại";
            }
            return null;
        }
    }
}
