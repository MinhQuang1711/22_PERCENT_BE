using _22Percent_BE.Data.DTOs.DetailIngredients;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Sevices.DetailIngredientServices
{
    public interface IDetailIngredientService
    {
        public Task<GetInventoryDto> GetAllByUserName(string userName);
        public Task<string?> UpdateList(List<UpdateDetailIngredientDto> dto, bool isPlusWeight); 
    }
}
