using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Entities
{
    public class DetailImportInvoice: BaseModel
    {
        public double price { get; set; }
        public double weight { get; set; }
        public string ingredientId { get; set; }
        public Ingredient ingredient { get; set; }
        public string importInvoiceId { get; set; }
        public ImportInvoices importInvoices { get; set; }


        public DetailImportInvoice() { }
    }
}
