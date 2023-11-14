using _22Percent_BE.Data.DTOs.Ingredients;
using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.DetailImportInvoices
{
    public class CreateDetailImportInvoiceDto
    {
        public double Price { get; set; }
        public double Weight { get; set; }  
        public string IngredientId { get; set; }
    }

    public static class CreateDetailImportInvoiceDtoEx
    {
        public static UpdateIngredientDto ToUpdateIngredientDto(this CreateDetailImportInvoiceDto dto)
        {
            return new UpdateIngredientDto 
            {
                Id=dto.IngredientId, 
                NetWeight= dto.Weight,
                ImportPrice = dto.Price,
            };
        }

        public static DetailImportInvoice ToDetailImportInvoice(this CreateDetailImportInvoiceDto dto, string importinvoiceId)
        {
            return new DetailImportInvoice
            {
                IngredientId=dto.IngredientId,
                ImportInvoiceId= importinvoiceId, 
                Weight= dto.Weight,
                Price= dto.Price,
            };
        }
    }
}
