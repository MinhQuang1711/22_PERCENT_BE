﻿using _22Percent_BE.Data.DTOs.PaymentInvoices;
using _22Percent_BE.Data.Repositories;

namespace _22Percent_BE.Sevices.SaleInvoices
{
    public class SaleInvoiceService : ISaleInvoiceService
    {
        private readonly IRepositoryManagement _repositoryManagement;

        public SaleInvoiceService(IRepositoryManagement repositoryManagement)
        {
            _repositoryManagement = repositoryManagement;
        }

        public async Task<List<GetSaleInvoiceDto>> GetAll()
        {
            var saleInvoices= await _repositoryManagement.saleInvoiceRepository.GetAll();
            return saleInvoices.Select(e=> e.ToGetSaleInvoiceDto()).ToList();
        }

        public async Task<GetSaleInvoiceDto?> GetById(string id)
        {
            var saleInvoice= await _repositoryManagement.saleInvoiceRepository.GetById(id);
            return saleInvoice?.ToGetSaleInvoiceDto();
        }
    }
}
