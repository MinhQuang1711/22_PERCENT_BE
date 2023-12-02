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


        public async Task create(Ingredient ingredient)
        {
           _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();  
        }

        private double caculatorRealWeight(double loss,double netWeight)
        {
            var realWeight = netWeight - (loss/100) * netWeight; 
            return realWeight;  
        }

        public async Task<bool> delete(string id)
        {
            var result= await _context.Ingredients.SingleOrDefaultAsync(e=> e.Id ==id);
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

        public async Task<Ingredient?> getById(string id)
        {
            return await _context.Ingredients.SingleOrDefaultAsync(e=> e.Id ==id);
        }

        public async Task<List<Ingredient>> search(SearchIngredientDto search)
        {
            var defaulTypeSearch = StringComparison.OrdinalIgnoreCase;
            var filter = _context.Ingredients.AsQueryable();

            if (search.Id != null)
            {
                filter = filter.Where(e => e.Id.Contains(search.Id, defaulTypeSearch));
            }
            if(search.Name != null)
            {
                filter = filter.Where(e => e.Name.Contains(search.Name,defaulTypeSearch));
            }

            return await filter.ToListAsync();
         
        }

        public async Task<bool> update(string id, UpdateIngredientDto update)
        {
            var result= await _context.Ingredients.SingleOrDefaultAsync(e => e.Id ==id);
            if (result != null) 
            {
                if (update.Name != null) 
                {
                    result.Name = update.Name;
                }
                if (update.Loss.HasValue) 
                {
                    result.Loss=update.Loss.Value;
                    result.RealWeight = caculatorRealWeight(result.Loss,result.NetWeight);
                    result.Cost = (result.ImportPrice/result.RealWeight);
                }
                if (update.ImportPrice.HasValue) 
                {
                    result.ImportPrice=update.ImportPrice.Value;
                    result.Cost = (result.ImportPrice / result.RealWeight);

                }
                if (update.NetWeight.HasValue) 
                {
                    result.NetWeight=update.NetWeight.Value;
                    result.RealWeight = caculatorRealWeight(result.Loss, result.NetWeight);
                    result.Cost = (result.ImportPrice / result.RealWeight);
                }
                _context.Update(result);
                await _context.SaveChangesAsync();
                return true;
                
            }
            return false;
        }

        public async Task<string?> UpdateList(List<UpdateIngredientDto> ingredientDtos)
        {
            foreach (var item in ingredientDtos)
            {
                var result = await _context.Ingredients.SingleOrDefaultAsync(e => e.Id == item.Id);
                if (result != null)
                {
                    if (item.Name != null)
                    {
                        result.Name = item.Name;
                    }
                    if (item.Loss.HasValue)
                    {
                        result.Loss = item.Loss.Value;
                        result.RealWeight = caculatorRealWeight(result.Loss, result.NetWeight);
                        result.Cost = (result.ImportPrice / result.RealWeight);
                    }
                    if (item.ImportPrice.HasValue)
                    {
                        result.ImportPrice = item.ImportPrice.Value;
                        result.Cost = (result.ImportPrice / result.RealWeight);

                    }
                    if (item.NetWeight.HasValue)
                    {
                        result.NetWeight = item.NetWeight.Value;
                        result.RealWeight = caculatorRealWeight(result.Loss, result.NetWeight);
                        result.Cost = (result.ImportPrice / result.RealWeight);
                    }
                    _context.Update(result);
                }
                await _context.SaveChangesAsync();
                return null;

            }
            return Message.IngredientNotExist;
            
        }
        
    }
}
