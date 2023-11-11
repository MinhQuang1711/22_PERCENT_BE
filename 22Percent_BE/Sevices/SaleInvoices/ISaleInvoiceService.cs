using _22Percent_BE.Data.DTOs.PaymentInvoices;

namespace _22Percent_BE.Sevices.SaleInvoices
{
    public interface ISaleInvoiceService
    {
        public Task<List<GetSaleInvoiceDto>> GetAll();
    }
}
