using _22Percent_BE.Data.DTOs.Ingredients;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.Ingredients
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepositoryManagement _managementRepository;

        public IngredientService(IRepositoryManagement managementRepository) 
        {
            _managementRepository= managementRepository;
        }

        public async Task create(CreateIngredientDto create, string currentUser)
        {
            var entity = create.ToIngredient(currentUser);
            await _managementRepository.IngredientRepository.create(entity);
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

        public async Task<string?> update( UpdateIngredientDto update)
        {
            var result = await _managementRepository.IngredientRepository.update(update.Id,update);
            if (result == false)
            {
                return "Nguyên liệu không tồn tại";
            }
            return null;
        }

        public async Task<string?> updateList(List<UpdateIngredientDto> dtoList)
        {
            return await _managementRepository.IngredientRepository.UpdateList(dtoList);
        }
    }
}
