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

        public async Task Create(SaleInvoices saleInvoices)
        {
            _context.SaleInvoices.Add(saleInvoices);
            await _context.SaveChangesAsync();  
        }

        public async Task<List<SaleInvoices>> GetAll()
        {
            var saleInvoices = await _context.SaleInvoices
                    .Include(e => e.DetailSaleInvoices)
                    .ThenInclude(e => e.Product)
                    .ToListAsync();
            return saleInvoices;
        }

        public async Task<SaleInvoices?> GetById(string id)
        {
            var saleInvoice = await _context.SaleInvoices
                .Include(e => e.DetailSaleInvoices)
                .ThenInclude(e => e.Product)
                .SingleOrDefaultAsync(e => e.Id == id);
            return saleInvoice; 
        }
    }
}
