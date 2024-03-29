﻿using _22Percent_BE.Data.Entities;

namespace _22Percent_BE.Data.DTOs.Ingredients
{
    public class UpdateIngredientDto :BaseModel
    {
        public double? Loss { get; set; }
        public string? Name {  get; set; } 
        public double? NetWeight { get; set; }
        public double? ImportPrice { get; set; }
    }
}
