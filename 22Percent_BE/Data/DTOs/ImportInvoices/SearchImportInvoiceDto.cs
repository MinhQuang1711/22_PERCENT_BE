namespace _22Percent_BE.Data.DTOs.ImportInvoices
{
    public class SearchImportInvoiceDto
    {
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set;}
        public string? InvoiceId { get; set;}
        public double? Price { get; set; }
    }
}
