using _22Percent_BE.Data.DTOs.ImportInvoices;

namespace _22Percent_BE.Sevices.ImportInvoices
{
    public interface IImportInvoiceService
    {
       
        public Task<string?> Delete(string id);
        public Task<List<GetImportInvoiceDto>> GetAll();
        public Task Create(CreateImportInvoiceDto dto);
        public Task<GetImportInvoiceDto?> GetById(string id);
    }
}
