using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Entities
{
    public class DetailImportInvoice: BaseModel
    {
        public double Price { get; set; }
        public double Weight { get; set; }
        public string IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public string ImportInvoiceId { get; set; }
        public ImportInvoices ImportInvoices { get; set; }


        public DetailImportInvoice() { }
    }
}
