using _22Percent_BE.Data.DTOs.DetailImportInvoices;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.DTOs.ImportInvoices
{
    public class GetImportInvoiceDto:BaseModel
    {
        public DateTime CreateDate { get; set; }    
        public double TotalPrice { get; set; }
        public List<GetDetailImportInvoiceDto> DetailImportPrices { get; set; }
    }

    public static class GetImportInvoiceDtoEx
    {
        public static GetImportInvoiceDto ToGetImportInvoiceDto(this _22Percent_BE.Data.Entities.Invoices.SubInvoices.ImportInvoices entity)
        {
            return new GetImportInvoiceDto
            {
                Id = entity.Id,
                CreateDate = entity.CreateDate,
                TotalPrice = entity.DetailImportInvoices.Sum(e => e.Price),
                DetailImportPrices= entity.DetailImportInvoices.Select(e=> e.ToGetDetailImportInvoiceDto()).ToList(),
            };
        }
    }
}
