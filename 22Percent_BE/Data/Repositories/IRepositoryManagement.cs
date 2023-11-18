using _22Percent_BE.Data.Repositories.ImportInvoiceRepo;
using _22Percent_BE.Data.Repositories.IngredientRepo;
using _22Percent_BE.Data.Repositories.PaymentInvoiceRepo;
using _22Percent_BE.Data.Repositories.ProductRepo;
using _22Percent_BE.Data.Repositories.SaleInvoiceRepo;
using _22Percent_BE.Data.Repositories.UserRepo;

namespace _22Percent_BE.Data.Repositories
{
    public interface IRepositoryManagement
    {

        public IUserRepository UserRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IIngredientRepository IngredientRepository { get; } 

        public ISaleInvoiceRepository saleInvoiceRepository { get; }

        public IImportInvoiceRepository ImportInvoiceRepository { get; }

        public IPaymentInvoiceRepository PaymentInvoiceRepository { get; }

    }
}
