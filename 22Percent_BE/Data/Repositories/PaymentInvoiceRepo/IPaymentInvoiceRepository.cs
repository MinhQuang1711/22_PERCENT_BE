using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Repositories.PaymentInvoiceRepo
{ 
    public interface IPaymentInvoiceRepository
    {
        public Task<string?> Delete(string id);
        public Task<List<PaymentInvoices>> GetAll();
        public Task Create(_22Percent_BE.Data.Entities.Invoices.SubInvoices.PaymentInvoices paymentInvoices);
    }
}
