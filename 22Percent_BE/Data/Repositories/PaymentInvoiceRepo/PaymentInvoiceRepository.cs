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

        public async Task<List<PaymentInvoices>> GetAll()
        {
            return await _context.PaymentInvoices.ToListAsync();
        }
    }
}
