﻿using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

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
    }
}
