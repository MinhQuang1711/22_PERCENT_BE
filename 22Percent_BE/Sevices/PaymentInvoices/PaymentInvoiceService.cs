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

        public async Task<List<Data.Entities.Invoices.SubInvoices.PaymentInvoices>> GetAll()
        {
           return await _repositoryManagement.PaymentInvoiceRepository.GetAll();
        }
    }
}
