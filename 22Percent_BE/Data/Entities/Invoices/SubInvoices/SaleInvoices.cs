﻿namespace _22Percent_BE.Data.Entities.Invoices.SubInvoices
{
    public class SaleInvoices: BaseInvoices
    {
        public int Quantity { set; get; }
        public double Discount { set; get; }
        public ICollection<DetailSaleInvoice> DetailSaleInvoices { set; get; }

        public SaleInvoices() { }
    }
}
