using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class FoodPerGram
{
    [Required] public int Id { get; set; }

    [Required] public string? Name { get; set; }

    [Required] public Brand? Brand { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
    [Required]
    public double Kcal { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Kj { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Carbohydrate { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Fat { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Protein { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Sugar { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Fibre { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
    public double SaturatedFat { get; set; }

    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Salt { get; set; }

    public ICollection<SearchName>? SearchNames { get; set; } = new List<SearchName>();
    public ICollection<FoodPerPiece>? FoodPerPieces { get; set; } = new List<FoodPerPiece>();
}