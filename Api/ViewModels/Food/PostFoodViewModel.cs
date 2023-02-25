using System.ComponentModel.DataAnnotations;
using Api.ViewModels.Pieces;

namespace Api.ViewModels.FoodPerGrams;

public class PostFoodViewModel
{
    [Required] public string Name { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "The value must be greater than zero.")]
    public int BrandId { get; set; }

    [Required] public double Kcal { get; set; }

    [Required] public double Kj { get; set; }

    [Required] public double Carbohydrate { get; set; }

    [Required] public double Fat { get; set; }

    [Required] public double Protein { get; set; }

    [Required] public double Sugar { get; set; }

    [Required] public double Fibre { get; set; }

    [Required] public double SaturatedFat { get; set; }

    [Required] public double Salt { get; set; }

    [Required]
    [RegularExpression(@"^G1(?:00)?$", ErrorMessage = "Must be 'G1' for 1 gram or 'G100' for 100 gram")]
    public string? GramType { get; set; }

    public ICollection<string>? SearchNames { get; set; } = new List<string>();
    public ICollection<PostPieceViewModel> Pieces { get; set; } = null!;
}