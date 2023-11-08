using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.Repositories.DetailProductRepo
{
    public class DetailProductRepository : IDetailProductRepository
    {
        private readonly _22Context _context;

        public DetailProductRepository(_22Context context)
        {
            _context=context;
        }    

        async Task<string?> IDetailProductRepository.CreateList(List<DetailProduct> list)
        {
            try
            {
                _context.DetailProducts.AddRange(list);
                await _context.SaveChangesAsync();
                return null;
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
             
        }
    }
}
