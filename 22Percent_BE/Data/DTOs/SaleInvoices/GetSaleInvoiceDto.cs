using _22Percent_BE.Data.DTOs.DetailPaymentInvoices;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.DTOs.PaymentInvoices
{
    public class GetSaleInvoiceDto:BaseModel
    {

        public int Quantity { get; set; }
        public double TotalPrice {  get; set; }
        public DateTime CreateDate { get; set; }
        public List<GetDetailSaleInvoiceDto> DetailSaleInvoices { get; set; }
    }

    public static class SaleInvoiceEx
    {
        public static GetSaleInvoiceDto ToGetSaleInvoiceDto(this SaleInvoices invoices) 
        {
            return new GetSaleInvoiceDto
            {
                Id = invoices.Id,
                TotalPrice = invoices.Total,
                Quantity = invoices.Quantity,
                CreateDate = invoices.CreateDate,
                DetailSaleInvoices = invoices.DetailSaleInvoices.Select(e=> e.ToDetailSaleInvoiceDto()).ToList(),
            }; 
        }
    }
}
