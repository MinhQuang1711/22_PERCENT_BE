using _22Percent_BE.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.DetailIngredientRepo
{
    public class DetailIngredientRepository : IDetailIngredientRepository
    {
        private readonly _22Context _context;

        public DetailIngredientRepository(_22Context context) 
        {
             _context= context;
        }
        public async Task Create(DetailIngredient entity)
        {
            _context.DetailIngredients.Add(entity);
            await _context.SaveChangesAsync();
        }

        private async Task<string?> Update(DetailIngredient entity, bool isPlusWeight)
        {
            var result = await _context.DetailIngredients.SingleOrDefaultAsync(e => e.IngredientId == entity.IngredientId);
            if (result == null)
            {
                return Message.IngredientNotExist; 
            }

            if (isPlusWeight)
            {
                result.Weight += entity.Weight; 
                result.ToalCost+= entity.ToalCost;
            }
            else
            {
                result.Weight -= entity.Weight;
                result.ToalCost -= entity.ToalCost;
            }
            _context.DetailIngredients.Update(result);      
            return null;

        }

        public async Task<string?> UpdateList(List<DetailIngredient> entity, bool isPlusWeight)
        {
            for (int i = 0; i < entity.Count; i++)
            {
                var message = await Update(entity[i], isPlusWeight);
                if (message != null)
                {
                    return message;
                }
            }
            await _context.SaveChangesAsync();
            return null;
           
        }

        public async Task<List<DetailIngredient>> GetAllByUserName(string userName)
        {
            return await _context.DetailIngredients
                 .Include(e => e.Ingredient)
                 .Where(e => e.Ingredient.CreateUser == userName)
                 .ToListAsync();
        }

        public async Task<List<DetailIngredient>> GetByIngredientName(string ingredientName, string userName)
        {
            var defaulTypeSearch = StringComparison.OrdinalIgnoreCase;
            return await _context.DetailIngredients
                .Include(e => e.Ingredient)
                .Where(e => e.Ingredient.CreateUser == userName)
                .Where(e => e.Ingredient.Name.Contains(ingredientName, defaulTypeSearch))
                .ToListAsync();
        }
    }
}
