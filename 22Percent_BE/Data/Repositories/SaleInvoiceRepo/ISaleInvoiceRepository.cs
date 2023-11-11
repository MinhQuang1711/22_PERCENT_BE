using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Repositories.SaleInvoiceRepo
{
    public interface ISaleInvoiceRepository
    {

        public Task<string?> Delete(string id);

        public Task<List<SaleInvoices>> GetAll();

        public Task<SaleInvoices?> GetById(string id);

        public Task Create(SaleInvoices saleInvoices);
        
    }
}
