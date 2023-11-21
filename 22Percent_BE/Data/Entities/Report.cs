namespace _22Percent_BE.Data.Entities
{
    public class Report: RelationshipWithUser
    { 
        

        public double Revenue { get; set; }

        public DateTime ToTime { get; set; }

        public double OtherCost { get; set; }

        public DateTime FromTime { get; set; }

        public double SaleProfit { get; set; }
       
        public double FinalProfit { get; set; }

        public double MaterialCost { get; set; }

        public DateTime CreateDate { get; set; }

        public Report() { }
    }
}
