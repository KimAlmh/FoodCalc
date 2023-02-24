using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

[Index(nameof(Weight), nameof(FoodPerGramId), IsUnique = true)]

public class FoodPerPiece
{
    [Required] public int Id { get; set; }
    
    [Required] public double Weight { get; set; }
    [Required] public int FoodPerGramId { get; set; }
    [Required] public FoodPerGram? FoodPerGram { get; set; }
}
