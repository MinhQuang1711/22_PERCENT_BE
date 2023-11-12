using _22Percent_BE.Data.DTOs.PaymentInvoices;
using _22Percent_BE.Data.DTOs.SaleInvoices;

namespace _22Percent_BE.Sevices.SaleInvoices
{
    public interface ISaleInvoiceService
    {
        public Task<string?> Delete(string id);

        public Task Create(CreateSaleInvoiceDto dto);

        public Task<List<GetSaleInvoiceDto>> GetAll();

        public Task<GetSaleInvoiceDto?> GetById(string id);

        public Task<List<GetSaleInvoiceDto>> GetByFilter(SearchSaleInvoiceDto dto); 

    }
}
