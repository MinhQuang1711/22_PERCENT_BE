using _22Percent_BE.Data.DTOs.DetailIngredients;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.DetailIngredientServices
{
    public class DetailIngredientService : IDetailIngredientService
    {
        private readonly IRepositoryManagement _repositoryManagement;

        public DetailIngredientService(IRepositoryManagement repositoryManagement) 
        {
            _repositoryManagement = repositoryManagement;
        }

        public async Task<string?> UpdateList(List<UpdateDetailIngredientDto> dtos, bool isPlusWeight)
        {
            var detailIngredinets = dtos.Select(e=> e.ToDetailIngredient()).ToList();
            return await _repositoryManagement.DetailIngredientRepository.UpdateList(detailIngredinets, isPlusWeight); 
        }
    }
}
