using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.DetailIngredientRepo
{
    public interface IDetailIngredientRepository
    {
        public Task Create(DetailIngredient entity);
        public Task<List<DetailIngredient>> GetAllByUserName(string userName);
        public Task<string?> UpdateList(List<DetailIngredient> entity, bool isPlusWeight);
    }
}
