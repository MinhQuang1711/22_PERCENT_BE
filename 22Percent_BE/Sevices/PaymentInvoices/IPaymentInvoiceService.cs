
namespace _22Percent_BE.Sevices.PaymentInvoices
{
    public interface IPaymentInvoiceService
    {
        public Task<List<_22Percent_BE.Data.Entities.Invoices.SubInvoices.PaymentInvoices>> GetAll();
    }
}
