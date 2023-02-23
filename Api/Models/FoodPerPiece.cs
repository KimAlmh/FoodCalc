﻿using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class FoodPerPiece
{
    [Required] public int Id { get; set; }
    
    [Required] public double Weight { get; set; }
    
    [Required] public FoodPerGram? FoodPerGram { get; set; }
}
