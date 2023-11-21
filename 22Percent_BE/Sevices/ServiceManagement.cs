using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.ImportInvoices;
using _22Percent_BE.Sevices.Ingredients;
using _22Percent_BE.Sevices.PaymentInvoices;
using _22Percent_BE.Sevices.Products;
using _22Percent_BE.Sevices.ReportServices;
using _22Percent_BE.Sevices.SaleInvoices;
using _22Percent_BE.Sevices.Tokens;

namespace _22Percent_BE.Sevices
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly Lazy<ITokenService> _tokenService;
        private readonly Lazy<IReportService> _reportService;
        private readonly Lazy<IProductService> _prductService;
        private readonly Lazy<IIngredientService> _ingredientService;
        private readonly Lazy<ISaleInvoiceService> _saleInvoiceService;
        private readonly Lazy<IImportInvoiceService> _importInvoiceService;
        private readonly Lazy<IPaymentInvoiceService> _paymentInvoiceService;
        private readonly Lazy<Authen.IAuthenticationService> _authenticationService;

        public ServiceManagement(IRepositoryManagement repositoryManagement,IConfiguration configuration, ITokenService tokenService) 
        {
            _tokenService = new Lazy<ITokenService>(() => new TokenService(configuration));

            _reportService = new Lazy<IReportService>(() => new ReportService(repositoryManagement));

            _prductService = new Lazy<IProductService>(() => new ProductService(repositoryManagement));

            _ingredientService = new Lazy<IIngredientService>(()=> new IngredientService(repositoryManagement));

            _saleInvoiceService = new Lazy<ISaleInvoiceService>(() => new SaleInvoiceService(repositoryManagement));

            _importInvoiceService = new Lazy<IImportInvoiceService>(() => new ImportInvoiceService(repositoryManagement));

            _paymentInvoiceService = new Lazy<IPaymentInvoiceService>(() => new PaymentInvoiceService(repositoryManagement));

            _authenticationService = new Lazy<Authen.IAuthenticationService>(() => new Authen.AuthenticationService(repositoryManagement,tokenService));
        }

        public Authen.IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IPaymentInvoiceService PaymentInvoiceService => _paymentInvoiceService.Value;

        public IImportInvoiceService ImportInvoiceService => _importInvoiceService.Value;

        public ISaleInvoiceService SaleInvoiceService => _saleInvoiceService.Value;

        public IIngredientService IngredientService => _ingredientService.Value;

        public IProductService ProductService => _prductService.Value;

        public IReportService ReportService => _reportService.Value;

        public ITokenService TokenService => _tokenService.Value;
    }
}
