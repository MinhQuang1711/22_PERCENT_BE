namespace _22Percent_BE.Data.Entities.Invoices.SubInvoices
{
    public class SaleInvoices
    {
        public double quantity { set; get; }
        public double discount { set; get; }
        public ICollection<DetailSaleInvoice> detailSaleInvoices { set; get; }

        public SaleInvoices() { }
    }
}
