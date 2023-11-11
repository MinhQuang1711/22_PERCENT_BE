using _22Percent_BE.Data.DTOs.DetailPaymentInvoices;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.PaymentInvoices
{
    public class GetSaleInvoiceDto:BaseModel
    {
        public int Quantity { get; set; }
        public double TotalPrice {  get; set; }
        public DateTime CreateDate { get; set; }
        public List<GetDetailSaleInvoiceDto> DetailSaleInvoices { get; set; }
    }
}
