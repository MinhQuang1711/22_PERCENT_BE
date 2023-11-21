using _22Percent_BE.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.InventoryRepo
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly _22Context _context;

        public InventoryRepository(_22Context context) 
        {
            _context = context;  
        }
        public async Task<Inventory?> GetByName(string nameStore) 
            => await  _context.Inventories
            .Include(e => e.DetailIngredients)
            .ThenInclude(e => e.Ingredient)
            .SingleOrDefaultAsync(e => e.Id == nameStore);   
    }
}
