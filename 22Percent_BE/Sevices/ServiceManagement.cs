using _22Percent_BE.Data.Repositories;
using _22Percent_BE.Sevices.Ingredients;
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

        public ServiceManagement(IRepositoryManagement repositoryManagement, IMapper mapper) 
        {
            _prductService = new Lazy<IProductService>(() => new ProductService(repositoryManagement));

            _ingredientService = new Lazy<IIngredientService>(()=> new IngredientService(repositoryManagement));

            _saleInvoiceService = new Lazy<ISaleInvoiceService>(() => new SaleInvoiceService(repositoryManagement));
        }

        public ISaleInvoiceService SaleInvoiceService => _saleInvoiceService.Value;

        public IIngredientService IngredientService => _ingredientService.Value;

        public IProductService ProductService => _prductService.Value;

    }
}
