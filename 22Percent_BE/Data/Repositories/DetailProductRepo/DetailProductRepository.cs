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

        public async Task<string?> CreateList(List<DetailProduct> list)
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

        public string? DeleteList(string productId)
        {
            var detailProduct= _context.DetailProducts.Find(productId);
            if (detailProduct != null)
            {
                _context.DetailProducts.Remove(detailProduct);
                _context.SaveChanges();
                return null;
            }
            return Message.DetailProductNotExist;
        }

        public async Task DeleteListAsync(string productId)
        {
            var detailProductList = _context.DetailProducts.Where(e => e.ProductId == productId).ToList();
            _context.DetailProducts.RemoveRange(detailProductList);
            await _context.SaveChangesAsync();
        }

        // async Task<string?> IDetailProductRepository.CreateList(List<DetailProduct> list)
        //{
        //    try
        //    {
        //        _context.DetailProducts.AddRange(list);
        //        await _context.SaveChangesAsync();
        //    }catch (Exception ex) 
        //    {
        //        return ex.Message;
        //    }

        //}


    }
}
