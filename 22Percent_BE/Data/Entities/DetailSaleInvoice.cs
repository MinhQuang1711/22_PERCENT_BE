using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Entities
{
    public class DetailSaleInvoice:BaseModel
    {
        public int quantity { get; set; }
        public Product product { get; set; }
        public string productId { get; set; }
        public string saleInvoiceId { get; set; }
        public SaleInvoices saleInvoices { get; set; }

        public DetailSaleInvoice() { }
    }
}
