using System.ComponentModel.DataAnnotations;
using Api.Enums;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

[Index(nameof(Name), nameof(BrandId), IsUnique = true)]
public class Food
{
    [Required] public int Id { get; set; }

    [Required] public string Name { get; set; } = null!;
    [Required] public int BrandId { get; set; }

    [Required] public Brand Brand { get; set; } = null!;

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Kcal { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Kj { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Carbohydrate { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Fat { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Protein { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Sugar { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Fibre { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number")]
    public double SaturatedFat { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Must be a positive number")]
    public double Salt { get; set; }
    
    [Required]
    public FoodType FoodType { get; set; }

    public ICollection<SearchName>? SearchNames { get; set; } = new List<SearchName>();
    public ICollection<Piece>? Pieces { get; set; } = new List<Piece>();
}