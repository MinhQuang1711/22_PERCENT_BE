using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.DTOs.PaymentInvoices
{
    public class CreatePaymentInvoiceDto
    {
        public double Price {  get; set; } 
        public string Description {  get; set; }
    }

    public static class CreatePaymentInvoiceDtoEx
    {
        public static _22Percent_BE.Data.Entities.Invoices.SubInvoices.PaymentInvoices ToPaymentInvoice(this CreatePaymentInvoiceDto dto)
        {
            return new _22Percent_BE.Data.Entities.Invoices.SubInvoices.PaymentInvoices
            {
               
                Total=dto.Price,
                CreateDate = DateTime.Now,
                Descriptions = dto.Description,
                Id = "HDX" + DateTime.Now.ToString("yyyyMMddHHmmss"),

            };
        }
    }
}
