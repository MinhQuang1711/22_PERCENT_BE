namespace _22Percent_BE.Data.Entities
{
    public class DetailIngredient:BaseModel
    {
    
        public double Weight { get; set; }  
        public double ToalCost { get; set; }
        public string InventoryId { get; set; }
        public string IngredientId { get; set; }
        public Inventory Inventory { get; set; }
        public Ingredient Ingredient { get; set; }

        public DetailIngredient() { }
    }
}
