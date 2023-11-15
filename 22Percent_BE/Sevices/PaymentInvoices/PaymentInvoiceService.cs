using _22Percent_BE.Data.DTOs.PaymentInvoices;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.PaymentInvoices
{
    public class PaymentInvoiceService : IPaymentInvoiceService
    {
        private readonly IRepositoryManagement _repositoryManagement;

        public PaymentInvoiceService(IRepositoryManagement repositoryManagement) 
        {
            _repositoryManagement = repositoryManagement;
        }

        public async Task Create(CreatePaymentInvoiceDto dto)
        {
            await _repositoryManagement.PaymentInvoiceRepository.Create(dto.ToPaymentInvoice());
        }

        public async Task<string?> Delete(string id)
        {
            return await _repositoryManagement.PaymentInvoiceRepository.Delete(id);
        }

        public async Task<List<Data.Entities.Invoices.SubInvoices.PaymentInvoices>> GetAll()
        {
           return await _repositoryManagement.PaymentInvoiceRepository.GetAll();
        }
    }
}
