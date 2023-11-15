using _22Percent_BE.Data.DTOs.PaymentInvoices;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.PaymentInvoiceRepo
{
    public class PaymentInvoiceRepository : IPaymentInvoiceRepository
    {
        private readonly _22Context _context;

        public PaymentInvoiceRepository(_22Context context) 
        {
            _context=context;
        }

        public async Task Create(PaymentInvoices paymentInvoices)
        {
            _context.PaymentInvoices.Add(paymentInvoices);
            await _context.SaveChangesAsync();
        }

        public async Task<string?> Delete(string id)
        {
            var entity = await  _context.PaymentInvoices.SingleOrDefaultAsync(e=> e.Id==id);
            if (entity != null)
            {
                _context.PaymentInvoices.Remove(entity);
                await _context.SaveChangesAsync();
                return null;
            }
            return Message.PaymentInvoiceNotExist;
        }

        public async Task<List<PaymentInvoices>> GetAll()
        {
            return await _context.PaymentInvoices.ToListAsync();
        }

        public async Task<List<PaymentInvoices>> GetByFilter(SearchPaymentInvoiceDto dto)
        {
            var defaulTypeSearch = StringComparison.OrdinalIgnoreCase;
            var filter = _context.PaymentInvoices.AsQueryable();
            if (dto.InvoiceId != null)
            {
                filter = filter.Where(e => e.Id.Contains(dto.InvoiceId, defaulTypeSearch));
            }
            if(dto.FromTime!=null && dto.ToTime != null)
            {
                filter = filter.Where(e => (e.CreateDate >= dto.FromTime) && (e.CreateDate <= dto.ToTime)); 
            }
            return await filter.ToListAsync();
        }
    }
}
