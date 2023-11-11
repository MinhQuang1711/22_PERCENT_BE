using _22Percent_BE.Data.Entities.Invoices.SubInvoices;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.SaleInvoiceRepo
{
    public class SaleInvoiceRepository : ISaleInvoiceRepository
    {
        private readonly _22Context _context;

        public SaleInvoiceRepository(_22Context context)
        {
            _context = context;
        }
        public async Task<List<SaleInvoices>> GetAll()
        {
            var saleInvoices = await _context.SaleInvoices
                    .Include(e => e.DetailSaleInvoices)
                    .ThenInclude(e => e.Product)
                    .ToListAsync();
            return saleInvoices;
        }
    }
}
