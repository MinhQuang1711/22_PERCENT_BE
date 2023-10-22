using _22Percent_BE.Data.DTOs.Ingredients;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Helpers.Mappers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.IngredientRepo
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly _22Context _context;
        private readonly IMapper _mapper;

        public IngredientRepository(_22Context context,IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;

        }


        public async Task<bool> create(CreateIngredientDto ingredientDto)
        {
            try
            {
                var ingredient= _mapper.Map<Ingredient>(ingredientDto);
                await _context.Ingredients.AddAsync(ingredient);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> delete(string id)
        {
            var result= await _context.Ingredients.SingleOrDefaultAsync(e=> e.id==id);
            if(result != null)
            {
                 _context.Ingredients.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;   
        }

        public async Task<List<Ingredient>> getAll()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<List<Ingredient>> search(SearchIngredientDto search)
        {
            var defaulTypeSearch = StringComparison.OrdinalIgnoreCase;
            var filter = _context.Ingredients.AsQueryable();

            if (search.Id != null)
            {
                filter = filter.Where(e => e.id.Contains(search.Id, defaulTypeSearch));
            }
            if(search.Name != null)
            {
                filter = filter.Where(e => e.name.Contains(search.Name,defaulTypeSearch));
            }

            return await filter.ToListAsync();
         
        }

        public async Task<bool> update(string id, UpdateIngredientDto update)
        {
            var result= await _context.Ingredients.SingleOrDefaultAsync(e => e.id==id);
            if (result != null) 
            {
                if (update.Name != null) 
                {
                    result.name = update.Name;
                }
                if (update.Loss.HasValue) 
                {
                    result.loss=update.Loss.Value;
                }
                if (update.ImportPrice.HasValue) 
                {
                    result.importPrice=update.ImportPrice.Value;
                }
                if (update.NetWeight.HasValue) 
                {
                    result.netWeight=update.NetWeight.Value;    
                }
                _context.Update(result);
                await _context.SaveChangesAsync();
                return true;
                
            }
            return false;
        }
    }
}
