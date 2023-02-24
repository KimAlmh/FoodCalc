using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Index(nameof(Name), nameof(FoodPerGramId), IsUnique = true)]

public class SearchName
{
    [Key]
    [Required] public int Id { get; set; }
    
    [Required] 
    public string? Name { get; set; }

    [Required]
    public int FoodPerGramId { get; set; }
    [Required]
    public FoodPerGram? FoodPerGram { get; set; }
}