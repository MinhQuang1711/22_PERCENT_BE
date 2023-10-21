namespace _22Percent_BE.Data.Entities.Invoices
{
    public class BaseInvoices : BaseModel
    {
        public DateTime createDate { get; set; }
        public string createUser { get; set; }  
        public double total {  get; set; }  

        public BaseInvoices() { }
    }
}
