using System.ComponentModel.DataAnnotations;
using Api.ViewModels.Food;

namespace Api.ViewModels.FoodPerPieces;

public class PostFoodPerPieceViewModel : PostFoodViewModel
{
    [Required] public double Weight { get; set; }

    [Required]
    [RegularExpression(@"^(?:PC|G100)$", ErrorMessage = "Must be 'PC' for piece or 'G100' for 100 gram")]
    public string? PieceType { get; set; }
}