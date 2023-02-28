using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

[Index(nameof(Name), nameof(FoodId), IsUnique = true)]
public class SearchName
{
    [Required] public int Id { get; set; }

    [Required] public string? Name { get; set; }

    [Required] public int FoodId { get; set; }

    [Required] public Food Food { get; set; }
}