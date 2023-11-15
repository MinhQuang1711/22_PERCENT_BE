using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.DetailSaleInvoices
{
    public class CreateDetailSaleInvoiceDto
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; }
    }

    public static class CreatDetailSaleInvoiceDtoEx
    {
        public static DetailSaleInvoice ToDetailSaleInvoice(this CreateDetailSaleInvoiceDto dto,string invoiceId)
        {
            return new DetailSaleInvoice 
            {
                SaleInvoiceId = invoiceId,
                ProductId = dto.ProductId, 
                Quantity = dto.Quantity,
                TotalPrice= dto.Price*dto.Quantity,     
            };
        }
    }
}
