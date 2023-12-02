
using _22Percent_BE.Sevices.DetailIngredientServices;
using _22Percent_BE.Sevices.ImportInvoices;
using _22Percent_BE.Sevices.Ingredients;
using _22Percent_BE.Sevices.PaymentInvoices;
using _22Percent_BE.Sevices.Products;
using _22Percent_BE.Sevices.ReportServices;
using _22Percent_BE.Sevices.SaleInvoices;
using _22Percent_BE.Sevices.Tokens;

namespace _22Percent_BE.Sevices
{
    public interface IServiceManagement
    {
        public _22Percent_BE.Sevices.Authen.IAuthenticationService AuthenticationService { get; }
        public IDetailIngredientService DetailIngredientService { get; }
        public IPaymentInvoiceService PaymentInvoiceService { get; }
        public IImportInvoiceService ImportInvoiceService { get; }
        public ISaleInvoiceService SaleInvoiceService { get; }
        public IIngredientService IngredientService { get; }
        public IProductService ProductService { get; }  
        public IReportService ReportService { get; }    
        public ITokenService TokenService { get; }

    }
}
