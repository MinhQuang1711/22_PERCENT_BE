namespace _22Percent_BE.Data.Entities
{
    public class Ingredient
    {
        public string name { get; set; }
        public double loss { get; set; }
        public double netWeight { get; set; }
        public double realWeight { get; set; }
        public double importPrice { get; set; }
        public ICollection<DetailProduct> detailProducts { get; set; }

        public Ingredient() { }
    }
}
