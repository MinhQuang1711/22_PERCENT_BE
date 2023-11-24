using _22Percent_BE.Data.DTOs.DetailImportInvoices;
using _22Percent_BE.Data.DTOs.DetailIngredients;
using _22Percent_BE.Data.DTOs.DetailProducts;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;
using _22Percent_BE.Sevices.ImportInvoices;

namespace _22Percent_BE.Data.DTOs.ImportInvoices
{
    public class CreateImportInvoiceDto
    {
        public List<CreateDetailImportInvoiceDto> DetailImportInvoice { get; set; }
    }

    public static class CreateImportInvoiceDtoEx 
    {
        public static _22Percent_BE.Data.Entities.Invoices.SubInvoices.ImportInvoices ToImportInvoice(this CreateImportInvoiceDto dto)
        {
            var id= "NL"+ DateTime.Now.ToString("yyyyMMddHHmmss");
            return new _22Percent_BE.Data.Entities.Invoices.SubInvoices.ImportInvoices
            {
                Id = id,
                CreateDate = DateTime.Now,
                DetailImportInvoices = dto.DetailImportInvoice.Select(e=> e.ToDetailImportInvoice(id)).ToList(),
                Total = GetTotalPrice(dto.DetailImportInvoice),
            };
        }

        private static double GetTotalPrice(List<CreateDetailImportInvoiceDto> list)
        {
            return list.Sum(e => e.Price); 
        }

        public static List<UpdateDetailIngredientDto> ToListDetailIngredient(this CreateImportInvoiceDto dto)
        {
            return dto.DetailImportInvoice.Select(e=> new UpdateDetailIngredientDto
            {        
                Weight = e.Weight,
                TotalCost= e.Price,
                IngredentID = e.IngredientId,
            }).ToList();   
        }

    }
}
