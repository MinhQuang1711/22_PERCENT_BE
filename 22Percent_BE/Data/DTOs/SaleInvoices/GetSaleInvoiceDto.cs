using _22Percent_BE.Data.DTOs.DetailPaymentInvoices;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;
using _22Percent_BE.Data.Enums;

namespace _22Percent_BE.Data.DTOs.PaymentInvoices
{
    public class GetSaleInvoiceDto:BaseModel
    {
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public double TotalPrice {  get; set; }
        public DateTime CreateDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public List<GetDetailSaleInvoiceDto> DetailSaleInvoices { get; set; }
    }

    public static class SaleInvoiceEx
    {
        public static GetSaleInvoiceDto ToGetSaleInvoiceDto(this _22Percent_BE.Data.Entities.Invoices.SubInvoices.SaleInvoices invoices) 
        {
            return new GetSaleInvoiceDto
            {
                Id = invoices.Id,   
                TotalPrice = invoices.Total,
                Quantity = invoices.Quantity,
                Discount = invoices.Discount,
                CreateDate = invoices.CreateDate,
                PaymentType = invoices.PaymentType,
                DetailSaleInvoices = invoices.DetailSaleInvoices.Select(e=> e.ToDetailSaleInvoiceDto()).ToList(),
            }; 
        }
    }
}
