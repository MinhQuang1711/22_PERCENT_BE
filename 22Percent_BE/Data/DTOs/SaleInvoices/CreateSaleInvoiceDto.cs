﻿using _22Percent_BE.Data.DTOs.DetailSaleInvoices;
using _22Percent_BE.Data.Entities;
using _22Percent_BE.Data.Entities.Invoices.SubInvoices;

namespace _22Percent_BE.Data.DTOs.SaleInvoices
{
    public class CreateSaleInvoiceDto
    {
        public double?Discount { get; set; }
        public List<CreateDetailSaleInvoiceDto> DetailSaleInvoiceDtos { get; set; }
    }

    public static class CreateSaleInvoiceDtoEx
    {
        public static _22Percent_BE.Data.Entities.Invoices.SubInvoices.SaleInvoices ToSaleInvoicce(this CreateSaleInvoiceDto dto)
        {
            var id= Guid.NewGuid().ToString();
            var detailSaleInvoices= dto.DetailSaleInvoiceDtos.Select(e=> e.ToDetailSaleInvoice(id)).ToList();
            return new Entities.Invoices.SubInvoices.SaleInvoices 
            {
                Id= id,
                Discount = dto.Discount??0,
                CreateDate=DateTime.Now,
                DetailSaleInvoices = detailSaleInvoices,
                Quantity = GetQuantity(detailSaleInvoices),
                Total = GetTotalPrice(dto.DetailSaleInvoiceDtos)- (dto.Discount??0),  
            };
        }

        private static int  GetQuantity(List<DetailSaleInvoice> list)
        {
            return list.Sum(e=>e.Quantity);
        }

        private static double GetTotalPrice(List<CreateDetailSaleInvoiceDto> list) 
        {
            return list.Sum(e => e.Quantity * e.Price);
        }
    }
}
