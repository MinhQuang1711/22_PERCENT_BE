using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.DetailPaymentInvoices
{
    public class GetDetailSaleInvoiceDto
    {
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string ProductName { get; set; }
    }

    public static class GetDetailSaleInvoiceDtoEx
    {
        public static GetDetailSaleInvoiceDto ToDetailSaleInvoiceDto(this DetailSaleInvoice detailInvoice)
        {
            return new GetDetailSaleInvoiceDto 
            {
                Quantity= detailInvoice.Quantity,
                ProductName= detailInvoice.Product.Name,
                TotalPrice = detailInvoice.Product.Price * detailInvoice.Quantity,
            };
        }
    }
}
