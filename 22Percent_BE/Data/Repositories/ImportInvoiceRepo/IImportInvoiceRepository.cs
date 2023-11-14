using _22Percent_BE.Data.DTOs.ImportInvoices;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Repositories.ImportInvoiceRepo
{
    public interface IImportInvoiceRepository
    {
        public Task<string?> Delete(string id);

        public Task Create(ImportInvoices create);
        
        public Task<List<ImportInvoices>> GetAll();

        public Task<ImportInvoices?> GetById(string id);

        public Task<List<ImportInvoices>> GetByFilter(SearchImportInvoiceDto dto);
    }
}
