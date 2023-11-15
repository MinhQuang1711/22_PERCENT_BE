
using _22Percent_BE.Data.DTOs.PaymentInvoices;

namespace _22Percent_BE.Sevices.PaymentInvoices
{
    public interface IPaymentInvoiceService
    {
        public Task Create(CreatePaymentInvoiceDto dto);
        public Task<List<_22Percent_BE.Data.Entities.Invoices.SubInvoices.PaymentInvoices>> GetAll();

    }
}
