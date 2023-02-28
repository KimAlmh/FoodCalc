using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

[Index(nameof(Weight), nameof(FoodId), IsUnique = true)]
public class Piece
{
    [Required] public int Id { get; set; }

    [Required] public string Name { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Must be a positive number greater than 0")]
    public double Weight { get; set; }

    [Required] public int FoodId { get; set; }
    [Required] public Food Food { get; set; } = null!;
}