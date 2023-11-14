using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Repositories.ImportInvoiceRepo
{
    public interface IImportInvoiceRepository
    {
        public Task Create(ImportInvoices create);
        public Task<string?> Delete(String id); 
    }
}
