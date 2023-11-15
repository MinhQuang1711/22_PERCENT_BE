using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.ImportInvoices;
using _22Percent_BE.Sevices.Ingredients;
using _22Percent_BE.Sevices.PaymentInvoices;
using _22Percent_BE.Sevices.Products;
using _22Percent_BE.Sevices.SaleInvoices;
using AutoMapper;

namespace _22Percent_BE.Sevices
{
    public class ServiceManagement : IServiceManagement
    {
        private readonly Lazy<IProductService> _prductService;
        private readonly Lazy<IIngredientService> _ingredientService;
        private readonly Lazy<ISaleInvoiceService> _saleInvoiceService;
        private readonly Lazy<IImportInvoiceService> _importInvoiceService;
        private readonly Lazy<IPaymentInvoiceService> _paymentInvoiceService;

        public ServiceManagement(IRepositoryManagement repositoryManagement, IMapper mapper) 
        {
            _prductService = new Lazy<IProductService>(() => new ProductService(repositoryManagement));

            _ingredientService = new Lazy<IIngredientService>(()=> new IngredientService(repositoryManagement));

            _saleInvoiceService = new Lazy<ISaleInvoiceService>(() => new SaleInvoiceService(repositoryManagement));

            _importInvoiceService = new Lazy<IImportInvoiceService>(() => new ImportInvoiceService(repositoryManagement));

            _paymentInvoiceService = new Lazy<IPaymentInvoiceService>(() => new PaymentInvoiceService(repositoryManagement));
        }

        public IPaymentInvoiceService PaymentInvoiceService => _paymentInvoiceService.Value;

        public IImportInvoiceService ImportInvoiceService => _importInvoiceService.Value;

        public ISaleInvoiceService SaleInvoiceService => _saleInvoiceService.Value;

        public IIngredientService IngredientService => _ingredientService.Value;

        public IProductService ProductService => _prductService.Value;

    }
}
