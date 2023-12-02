using _22Percent_BE.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.DetailProductRepo
{
    public class DetailProductRepository : IDetailProductRepository
    {
        private readonly _22Context _context;

        public DetailProductRepository(_22Context context) 
        {
            _context = context;
        }
        public async Task<List<DetailProduct>> GetByProductId(string productId)
        {
            return await _context.DetailProducts.Where(e=> e.ProductId == productId)
                .Include(e=> e.Ingredient)
                .ThenInclude(e=> e.DetailIngredient)
            .ToListAsync();
        }
    }
}
