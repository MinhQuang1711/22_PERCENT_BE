﻿namespace _22Percent_BE.Data.Entities
{
    public class Product: BaseModel
    {

        public double Profit { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string CreateUser { get; set; }
        public ICollection<DetailProduct> DetailProducts { get; set; }  
        public ICollection<DetailSaleInvoice> DetailSaleInvoices { get; set; }

        public Product() { }
    }
}
