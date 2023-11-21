namespace _22Percent_BE.Data.Entities
{
    public class Inventory: BaseModel
    {

        public double TotalCost { get; set; }
        public ICollection<DetailIngredient> DetailIngredients { get; set; }

        public Inventory() { }

    }
}
