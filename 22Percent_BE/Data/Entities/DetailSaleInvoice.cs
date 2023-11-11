using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Entities
{
    public class DetailSaleInvoice:BaseModel
    {
        
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public string ProductId { get; set; }
        public double TotalPrice { get; set; }
        public string SaleInvoiceId { get; set; }
        public SaleInvoices SaleInvoices { get; set; }

        public DetailSaleInvoice() { }
    }
}
