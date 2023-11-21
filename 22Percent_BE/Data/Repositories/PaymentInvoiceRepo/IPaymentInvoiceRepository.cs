using _22Percent_BE.Data.Entities.Invoices.SubInvoices;
using _22Percent_BE.Data.DTOs.PaymentInvoices;
namespace _22Percent_BE.Data.Repositories.PaymentInvoiceRepo
{ 
    public interface IPaymentInvoiceRepository
    {
        public Task<string?> Delete(string id);
        public Task<List<PaymentInvoices>> GetAll();
        public Task<List<PaymentInvoices>> GetByFilter(SearchPaymentInvoiceDto dto, string currentUser);
        public Task Create(_22Percent_BE.Data.Entities.Invoices.SubInvoices.PaymentInvoices paymentInvoices);
    }
}
