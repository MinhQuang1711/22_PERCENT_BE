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

        public async Task Create(CreateImportInvoiceDto dto, string currentUser)
        {
            var inportInvoice= dto.ToImportInvoice();
            inportInvoice.CreateUser=currentUser;   
            await _repositoryManagement.ImportInvoiceRepository.Create(inportInvoice);
        }

        public async Task<string?> Delete(string id)
        {
            return await _repositoryManagement.ImportInvoiceRepository.Delete(id);
        }

        public async Task<List<GetImportInvoiceDto>> GetAll(string currentUser)
        {
            var entities= await _repositoryManagement.ImportInvoiceRepository.GetAll();
            entities = entities.Where(e => e.CreateUser == currentUser).ToList();
            return entities.Select(e=> e.ToGetImportInvoiceDto()).ToList();
        }

        public async Task<List<GetImportInvoiceDto>> GetByFilter(SearchImportInvoiceDto dto, string currentUser)
        {
            var entities = await _repositoryManagement.ImportInvoiceRepository.GetByFilter(dto, currentUser);   
            return entities.Select(e => e.ToGetImportInvoiceDto()).ToList();
        }

        public async Task<GetImportInvoiceDto?> GetById(string id)
        {
            var dto= await _repositoryManagement.ImportInvoiceRepository.GetById(id);
            return dto?.ToGetImportInvoiceDto();
        }
    }
}
