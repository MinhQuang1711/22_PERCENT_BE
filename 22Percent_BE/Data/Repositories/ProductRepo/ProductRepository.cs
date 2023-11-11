using _22Percent_BE.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly _22Context _context;

        public ProductRepository(_22Context context)
        {
            _context=context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await  _context.Products
                .Include(e=> e.DetailProducts)
                .ThenInclude(e=> e.Ingredient)
                .ToListAsync();
                
        }
    }
}
