using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.Entities
{
    public class User:RelationshipWithUser
    {
        public string Password { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<SaleInvoices> SaleInvoices { get; set; }
        public ICollection<ImportInvoices> ImportInvoices { get; set; }
        public ICollection<PaymentInvoices> PaymentInvoices { get; set; }
        public User() { }
    }
}
