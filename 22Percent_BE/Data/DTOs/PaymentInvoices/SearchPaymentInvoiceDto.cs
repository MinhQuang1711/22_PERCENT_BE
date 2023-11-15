namespace _22Percent_BE.Data.DTOs.PaymentInvoices
{
    public class SearchPaymentInvoiceDto
    {
        public string? InvoiceId { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set;}
    }
}
