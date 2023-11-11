using _22Percent_BE.Data.DTOs.Products;
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

        public async Task<string?> Create(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }

        public async Task<List<Product>> GetAll()
        {
            return await  _context.Products
                .Include(e=> e.DetailProducts)
                .ThenInclude(e=> e.Ingredient)
                .ToListAsync();
                
        }

        public async Task<Product?> GetById(string id)
        {
            return await _context.Products
                .Include(e=> e.DetailProducts)
                .ThenInclude(e=> e.Ingredient)
                .SingleOrDefaultAsync(e=> e.Id==id);
        }

        public async Task<List<Product>> SearchByFilter(SearchProductDto search)
        {
            var defaulTypeSearch = StringComparison.OrdinalIgnoreCase;
            var filter = _context.Products.AsQueryable();
            if(search.Name != null)
            {
                filter= filter.Where(e => e.Name.Contains(search.Name, defaulTypeSearch));
            }
            if(search.FromPrice!=null && search.ToPrice != null)
            {
                filter= filter.Where(e => (e.Price>=search.FromPrice) && (e.Price<=search.ToPrice));
            }
            return await filter
                .Include(e=> e.DetailProducts)
                .ThenInclude(e=> e.Ingredient)
                .ToListAsync();
        }
    }
}
