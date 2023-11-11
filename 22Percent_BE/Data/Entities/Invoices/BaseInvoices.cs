namespace _22Percent_BE.Data.Entities.Invoices
{
    public class BaseInvoices : BaseModel
    {
        public DateTime CreateDate { get; set; } 
        public double Total {  get; set; }  

        public BaseInvoices() { }
    }
}
