using _22Percent_BE.Data.DTOs.DetailIngredients;

namespace _22Percent_BE.Sevices.DetailIngredientServices
{
    public interface IDetailIngredientService
    {
        public Task<string?> UpdateList(List<UpdateDetailIngredientDto> dto, bool isPlusWeight); 
    }
}
