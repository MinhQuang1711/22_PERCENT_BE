﻿namespace _22Percent_BE.Data.Entities
{
    public class Ingredient: RelationshipWithUser
    {
        public string Name { get; set; }
        public double Loss { get; set; }
        public double Cost { get; set; }
        public double NetWeight { get; set; }
        public double RealWeight { get; set; }
        public double ImportPrice { get; set; }
        public DetailIngredient? DetailIngredient { get; set; }
        public ICollection<DetailProduct> DetailProducts { get; set; }
        public ICollection<DetailImportInvoice> DetailImportInvoices { get; set; }  

        public Ingredient() { }
    }
}
