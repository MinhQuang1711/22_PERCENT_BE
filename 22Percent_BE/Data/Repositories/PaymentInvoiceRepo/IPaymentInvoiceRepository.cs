using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Repositories.PaymentInvoiceRepo
{ 
    public interface IPaymentInvoiceRepository
    {
        public Task<List<PaymentInvoices>> GetAll(); 
    }
}
