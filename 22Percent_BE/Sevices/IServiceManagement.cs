using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.ImportInvoices;
using _22Percent_BE.Sevices.Ingredients;
using _22Percent_BE.Sevices.Products;
using _22Percent_BE.Sevices.SaleInvoices;

namespace _22Percent_BE.Sevices
{
    public interface IServiceManagement
    {
        public IImportInvoiceService ImportInvoiceService { get; }
        public ISaleInvoiceService SaleInvoiceService { get; }
        public IIngredientService IngredientService { get; }
        public IProductService ProductService { get; }

    }
}
