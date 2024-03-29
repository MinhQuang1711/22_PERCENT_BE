﻿using _22Percent_BE.Data.DTOs.SaleInvoices;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;
using Microsoft.EntityFrameworkCore;

namespace _22Percent_BE.Data.Repositories.SaleInvoiceRepo
{
    public class SaleInvoiceRepository : ISaleInvoiceRepository
    {
        private readonly _22Context _context;

        public SaleInvoiceRepository(_22Context context)
        {
            _context = context;
        }

        public async Task Create(SaleInvoices saleInvoices)
        {
            _context.SaleInvoices.Add(saleInvoices);
            await _context.SaveChangesAsync();  
        }

        public async Task<string?> Delete(string id)
        {
            var saleInvoice = _context.SaleInvoices.SingleOrDefault(e => e.Id == id);
            if (saleInvoice!=null)
            {
                _context.SaleInvoices.Remove(saleInvoice);
                await _context.SaveChangesAsync();
                return null;
            }
            return Message.SaleInvoiceNotExist; 
        }

        public async Task<List<SaleInvoices>> GetAll()
        {
            var saleInvoices = await _context.SaleInvoices
                    .Include(e => e.DetailSaleInvoices)
                    .ThenInclude(e => e.Product)
                    .ToListAsync();
            return saleInvoices;
        }

        public async Task<List<SaleInvoices>> GetByFilter(SearchSaleInvoiceDto dto)
        {
            var filter = _context.SaleInvoices.AsQueryable();
            if (dto.SaleInvoiceId != null)
            {
                filter = filter.Where(e => e.Id == dto.SaleInvoiceId);
            }
            if (dto.PaymentType != null)
            {
                filter = filter.Where(e => e.PaymentType == dto.PaymentType);
            }
            if (dto.FromTime != null && dto.EndTime != null)
            {
                filter = filter.Where(e => e.CreateDate >= dto.FromTime && e.CreateDate <= dto.EndTime);
            }
            return await filter
                .Include(e => e.DetailSaleInvoices) 
                .ThenInclude(e => e.Product)
                .ToListAsync();
        }

        public async Task<SaleInvoices?> GetById(string id)
        {
            var saleInvoice = await _context.SaleInvoices
                .Include(e => e.DetailSaleInvoices)
                .ThenInclude(e => e.Product)
                .SingleOrDefaultAsync(e => e.Id == id);
            return saleInvoice; 
        }
    }
}
