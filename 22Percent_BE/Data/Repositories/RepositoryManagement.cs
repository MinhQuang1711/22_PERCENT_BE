using _22Percent_BE.Data.Repositories.ImportInvoiceRepo;
using _22Percent_BE.Data.Repositories.IngredientRepo;
using _22Percent_BE.Data.Repositories.PaymentInvoiceRepo;
using _22Percent_BE.Data.Repositories.ProductRepo;
using _22Percent_BE.Data.Repositories.SaleInvoiceRepo;
using _22Percent_BE.Data.Repositories.UserRepo;
using AutoMapper;

namespace _22Percent_BE.Data.Repositories
{
    public class RepositoryManagement : IRepositoryManagement
    {
        private readonly Lazy<IUserRepository> _lazyUserRepository;
        private readonly Lazy<IProductRepository> _lazyProductRepository;
        private readonly Lazy<IIngredientRepository> _lazyIngredientRepository;
        private readonly Lazy<ISaleInvoiceRepository> _lazySaleInvoiceRepository;
        private readonly Lazy<IImportInvoiceRepository> _lazyImportInvoiceRepository;
        private readonly Lazy<IPaymentInvoiceRepository> _lazyPaymentInvoiceRepository;

        public RepositoryManagement(_22Context context,IMapper mapper) 
        {

            _lazyUserRepository = new Lazy<IUserRepository>(() => new UserRepository(context));

            _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));

            _lazySaleInvoiceRepository = new Lazy<ISaleInvoiceRepository>(() => new SaleInvoiceRepository(context));

            _lazyIngredientRepository = new Lazy<IIngredientRepository>(()=> new IngredientRepository(context,mapper));  

            _lazyImportInvoiceRepository = new Lazy<IImportInvoiceRepository>(() => new ImportInvoiceRepository(context));

            _lazyPaymentInvoiceRepository = new Lazy<IPaymentInvoiceRepository>(() => new PaymentInvoiceRepository(context));

        }

        public IUserRepository UserRepository => _lazyUserRepository.Value;

        public IProductRepository ProductRepository => _lazyProductRepository.Value;

        public IIngredientRepository IngredientRepository => _lazyIngredientRepository.Value;

        public ISaleInvoiceRepository saleInvoiceRepository => _lazySaleInvoiceRepository.Value;

        public IImportInvoiceRepository ImportInvoiceRepository => _lazyImportInvoiceRepository.Value;

        public IPaymentInvoiceRepository PaymentInvoiceRepository => _lazyPaymentInvoiceRepository.Value;
    }
}
