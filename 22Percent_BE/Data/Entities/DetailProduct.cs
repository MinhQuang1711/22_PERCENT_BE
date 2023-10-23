namespace _22Percent_BE.Data.Entities
{
    public class DetailProduct:BaseModel
    {
        public double Cost { get; set; }    
        public double Weight { get; set; }
        public Product Product { get; set; }
        public string ProductId { get; set; }
        public string IngredientID { get; set; }  
        public Ingredient Ingredient { get; set; }
        
        public DetailProduct() { }
    }
}
