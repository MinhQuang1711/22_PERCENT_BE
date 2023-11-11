namespace _22Percent_BE.Data.Entities.Invoices.SubInvoices
{
    public class SaleInvoices: BaseInvoices
    {
        public double Quantity { set; get; }
        public double Discount { set; get; }
        public ICollection<DetailSaleInvoice> detailSaleInvoices { set; get; }

        public SaleInvoices() { }
    }
}
