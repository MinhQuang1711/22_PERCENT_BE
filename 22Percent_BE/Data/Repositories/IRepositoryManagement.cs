using _22Percent_BE.Data.Repositories.IngredientRepo;
using _22Percent_BE.Data.Repositories.ProductRepo;
using _22Percent_BE.Data.Repositories.SaleInvoiceRepo;

namespace _22Percent_BE.Data.Repositories
{
    public interface IRepositoryManagement
    {
        public IProductRepository ProductRepository { get; }

        public IIngredientRepository IngredientRepository { get; } 

        public ISaleInvoiceRepository saleInvoiceRepository { get; }

    }
}
