namespace _22Percent_BE.Data.Entities.Invoices.SubInvoices
{
    public class ImportInvoices : BaseInvoices
    {
        public ICollection<DetailImportInvoice> detailImportInvoices {  get; set; }

        public ImportInvoices() { }
    }
}
