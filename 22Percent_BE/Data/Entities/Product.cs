namespace _22Percent_BE.Data.Entities
{
    public class Product: BaseModel
    {


        public double cost { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string createUser { get; set; }
        public ICollection<DetailProduct> detailProducts { get; set; }  
        public ICollection<DetailSaleInvoice> detailSaleInvoices { get; set; }

        public Product() { }
    }
}
