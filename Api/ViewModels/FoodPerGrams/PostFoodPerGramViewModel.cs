using System.ComponentModel.DataAnnotations;
using Api.ViewModels.Food;

namespace Api.ViewModels.FoodPerGrams;

public class PostFoodPerGramViewModel : PostFoodViewModel
{
    [Required]
    [RegularExpression(@"^G1(?:00)?$", ErrorMessage = "Must be 'G1' for 1 gram or 'G100' for 100 gram")]
    public string? GramType { get; set; }
}