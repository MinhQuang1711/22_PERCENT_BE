using _22Percent_BE.Data.Entities.Invoices.SubInvoices;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.ImportInvoiceRepo
{
    public class ImportInvoiceRepository : IImportInvoiceRepository
    {
        private readonly _22Context _context;

        public ImportInvoiceRepository(_22Context context) 
        {
            _context= context;    
        }

        public async Task Create(ImportInvoices create)
        {
            _context.ImportInvoices.Add(create);    
            await _context.SaveChangesAsync();
        }

        public async Task<string?> Delete(string id)
        {
            var importinvoice = await _context.ImportInvoices.SingleOrDefaultAsync(e=> e.Id==id);
            if(importinvoice!=null)
            {
                _context.ImportInvoices.Remove(importinvoice);
                await _context.SaveChangesAsync();
                return null;
            }
            return Message.ImportInvoiceNotExist; 
            
        }

        public async Task<List<ImportInvoices>> GetAll()
        {
           return await _context.ImportInvoices
                .Include(e=> e.DetailImportInvoices)
                    .ThenInclude(e=> e.Ingredient)
                .ToListAsync();
        }
    }
}
