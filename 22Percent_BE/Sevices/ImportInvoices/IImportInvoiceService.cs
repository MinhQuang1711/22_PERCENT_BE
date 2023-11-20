using _22Percent_BE.Data.DTOs.ImportInvoices;

namespace _22Percent_BE.Sevices.ImportInvoices
{
    public interface IImportInvoiceService
    {
       
        public Task<string?> Delete(string id);

        public Task<GetImportInvoiceDto?> GetById(string id);

        public Task<List<GetImportInvoiceDto>> GetAll(string currentUser);

        public Task Create(CreateImportInvoiceDto dto, string currentUser);


        public Task<List<GetImportInvoiceDto>> GetByFilter(SearchImportInvoiceDto dto, string currentUser);
    }
}
