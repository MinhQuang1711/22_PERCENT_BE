using _22Percent_BE.Data.DTOs.ImportInvoices;
using _22Percent_BE.Data.DTOs.PaymentInvoices;
using _22Percent_BE.Data.DTOs.Report;
using _22Percent_BE.Data.DTOs.SaleInvoices;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.ReportServices
{
    public class ReportService : IReportService
    {
        private readonly IRepositoryManagement _repositoryManagement;

        public ReportService(IRepositoryManagement repositoryManagement) 
        {
            _repositoryManagement = repositoryManagement;
        }

        public async Task Create(CreateReportDto dto, string currentUser)
        {
            // Lấy hóa đơn bán để tính doanh thu và lãi
            var seachrInvoiceDto = new SearchSaleInvoiceDto { FromTime = dto.FromTime, EndTime = dto.ToTime };
            var saleInvoices = await _repositoryManagement.saleInvoiceRepository.GetByFilter(seachrInvoiceDto, currentUser);

            // Lấy hóa đơn nhập tính chi phí nguyên liệu
            var searchImportInvoice = new SearchImportInvoiceDto { FromTime = dto.FromTime, ToTime = dto.ToTime };
            var importInvoices = await _repositoryManagement.ImportInvoiceRepository.GetByFilter(searchImportInvoice, currentUser);

            // Lấy danh sách hóa đơn chi tính chi phí khác
            var searchPaymentInvoice = new SearchPaymentInvoiceDto { FromTime = dto.FromTime, ToTime = dto.ToTime };
            var paymentInvoice = await _repositoryManagement.PaymentInvoiceRepository.GetByFilter(searchPaymentInvoice, currentUser);

            // Doanh thu (1)
            var saleRevenue = saleInvoices.Sum(e => e.Total);
            // Chi phí khác (2)
            var otherCost = paymentInvoice.Sum(e => e.Total);
            // Chi phí nguyên liệu (3)
            var materialCost = importInvoices.Sum(e => e.Total);
            // Lợi nhuận doanh thu (4)
            var saleProfit = saleInvoices.Sum (e=> e.DetailSaleInvoices.Sum(e=> e.Quantity*e.Product.Profit));
            // Lợi nhuận cuối = (4) - (3) - (2)
            var finalProfit = saleProfit - materialCost - otherCost;

            var report = new Report 
            {
                ToTime= dto.ToTime,
                OtherCost = otherCost,
                Revenue = saleRevenue,
                FromTime = dto.FromTime,
                SaleProfit = saleProfit,
                CreateUser = currentUser,
                FinalProfit = finalProfit,
                MaterialCost = materialCost,
                Id = "BC"+DateTime.Now.ToString("yyyyMMddHHmmss"),
            };
            await _repositoryManagement.ReportRepository.Create(report); 
        }

        public async Task<string?> Delete(string id)
        {
            return await _repositoryManagement.ReportRepository.Delete(id); 
        }

        public async Task<List<Report>> GetByFilter(string userName, SearchReportDto dto)
        {
            return await _repositoryManagement.ReportRepository.GetByFilter(userName, dto.FromTime, dto.ToTime); 
        }

        public Task<List<Report>> GetByUserName(string userName)
        {
            return _repositoryManagement.ReportRepository.GetByUserName(userName);
        }
    }
}
