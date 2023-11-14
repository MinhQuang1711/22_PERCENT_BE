using _22Percent_BE.Data.DTOs.ImportInvoices;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.ImportInvoices
{
    public class ImportInvoiceService : IImportInvoiceService
    {
        private readonly IRepositoryManagement _repositoryManagement;

        public ImportInvoiceService(IRepositoryManagement repositoryManagement) 
        {
            _repositoryManagement = repositoryManagement;
        }

        public async Task Create(CreateImportInvoiceDto dto)
        {
            var inportInvoice= dto.ToImportInvoice();
            await _repositoryManagement.ImportInvoiceRepository.Create(inportInvoice);
        }

        public async Task<string?> Delete(string id)
        {
            return await _repositoryManagement.ImportInvoiceRepository.Delete(id);
        }

        public async Task<List<GetImportInvoiceDto>> GetAll()
        {
            var entities= await _repositoryManagement.ImportInvoiceRepository.GetAll();
            return entities.Select(e=> e.ToGetImportInvoiceDto()).ToList();
        }
    }
}
