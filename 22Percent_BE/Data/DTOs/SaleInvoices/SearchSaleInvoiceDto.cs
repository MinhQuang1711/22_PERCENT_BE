using _22Percent_BE.Data.Enums;

namespace _22Percent_BE.Data.DTOs.SaleInvoices
{
    public class SearchSaleInvoiceDto
    {
        public DateTime? EndTime { get; set; }
        public DateTime? FromTime { get; set; }
        public string? SaleInvoiceId { get; set; }
        public PaymentType? PaymentType { get; set; }
    }
}
