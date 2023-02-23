using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.Food;

public abstract class PostFoodViewModel
{
    [Required] public string? Name { get; set; }

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
}