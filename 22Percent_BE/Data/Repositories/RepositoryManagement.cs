using _22Percent_BE.Data.Repositories.IngredientRepo;
using _22Percent_BE.Data.Repositories.ProductRepo;
using _22Percent_BE.Data.Repositories.SaleInvoiceRepo;
using AutoMapper;

namespace _22Percent_BE.Data.Repositories
{
    public class RepositoryManagement : IRepositoryManagement
    {
        private readonly Lazy<IProductRepository> _lazyProductRepository;
        private readonly Lazy<IIngredientRepository> _lazyIngredientRepository;
        private readonly Lazy<ISaleInvoiceRepository> _lazySaleInvoiceRepository;

        public RepositoryManagement(_22Context context,IMapper mapper) 
        {
            _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));

            _lazyIngredientRepository = new Lazy<IIngredientRepository>(()=> new IngredientRepository(context,mapper));

            _lazySaleInvoiceRepository = new Lazy<ISaleInvoiceRepository>(() => new SaleInvoiceRepository(context));

        }

        public IProductRepository ProductRepository => _lazyProductRepository.Value;

        public IIngredientRepository IngredientRepository => _lazyIngredientRepository.Value;

        public ISaleInvoiceRepository saleInvoiceRepository => _lazySaleInvoiceRepository.Value;
    }
}
