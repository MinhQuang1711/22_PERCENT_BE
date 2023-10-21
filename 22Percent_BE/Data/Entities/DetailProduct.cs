namespace _22Percent_BE.Data.Entities
{
    public class DetailProduct:BaseModel
    {
        public Product product { get; set; }
        public string productId { get; set; }
        public string ingredientID { get; set; }  
        public Ingredient ingredient { get; set; }
        
        public DetailProduct() { }
    }
}
