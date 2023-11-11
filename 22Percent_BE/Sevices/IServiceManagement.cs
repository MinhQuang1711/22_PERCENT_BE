using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.Ingredients;
using _22Percent_BE.Sevices.Products;
using _22Percent_BE.Sevices.SaleInvoices;

namespace _22Percent_BE.Sevices
{
    public interface IServiceManagement
    {
        public ISaleInvoiceService SaleInvoiceService { get; }
        public IIngredientService IngredientService { get; }
        public IProductService ProductService { get; }

    }
}
