using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class SearchName
{
    
    [Required] public int Id { get; set; }
    
    [Required] public string? Name { get; set; }
    
    [Required] public FoodPerGram? FoodPerGram { get; set; }
}