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

        async Task IDetailProductRepository.CreateList(List<DetailProduct> list)
        {
                _context.DetailProducts.AddRange(list);
                await _context.SaveChangesAsync();       
        }

        async Task IDetailProductRepository.DeleteList(string productId)
        {
            var detailProductList = _context.DetailProducts.Where(e=> e.ProductId==productId).ToList();
            _context.DetailProducts.RemoveRange(detailProductList);
            await _context.SaveChangesAsync();
        }
    }
}
