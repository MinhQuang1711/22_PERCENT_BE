using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.DTOs.Products;
using _22Percent_BE.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly _22Context _context;
        private readonly IMapper _mapper;

        public ProductRepository(_22Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Product?> GetById(string id)
        {
            
            return await _context.Products
                .Include(e=> e.DetailProducts)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Products.Include(e => e.DetailProducts).ToListAsync();
            return products;
        }

        public async Task<string?> Delete(string id)
        {
            var result = await _context.Products.SingleOrDefaultAsync(e => e.Id == id);
            if (result == null)
            {
                return "Sản phẩm không tồn tại";
            }
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<string?> Create(Product create)
        {
            try
            {
                _context.Products.Add(create);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Product>> GetByName(string name)
        {
            var products =  _context.Products.Where(e=> e.Name.Contains(e.Name, StringComparison.OrdinalIgnoreCase));

            return await products.ToListAsync();   
        }
    }
}
