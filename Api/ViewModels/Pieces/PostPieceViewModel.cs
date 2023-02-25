using System.ComponentModel.DataAnnotations;
using Api.Utils;

namespace Api.ViewModels.Pieces;

public class PostPieceViewModel
{
    [Required]
    public double Weight { get; set; }
    [Required]
    public string Name { get; set; } = null!;
}