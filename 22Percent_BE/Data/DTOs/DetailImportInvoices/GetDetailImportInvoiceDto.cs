using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.DetailImportInvoices
{
    public class GetDetailImportInvoiceDto
    {
        public double Price { get; set; }
        public double Weight { get; set; }
        public string IngredientName { get; set; }
    }

    public static class GetDetailImportInvoiceDtoEx
    {
        public static GetDetailImportInvoiceDto ToGetDetailImportInvoiceDto(this DetailImportInvoice entity)
        {
            return new GetDetailImportInvoiceDto 
            {
                Price = entity.Price,
                Weight = entity.Weight, 
                IngredientName= entity.Ingredient.Name
            };
        }
    }
}
