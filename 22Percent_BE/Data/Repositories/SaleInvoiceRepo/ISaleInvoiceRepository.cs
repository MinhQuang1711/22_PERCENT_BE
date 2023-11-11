using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Repositories.SaleInvoiceRepo
{
    public interface ISaleInvoiceRepository
    {
        public Task<List<SaleInvoices>> GetAll(); 
    }
}
