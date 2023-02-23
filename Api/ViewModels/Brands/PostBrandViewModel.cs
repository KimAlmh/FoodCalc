using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.Brands;

public class PostBrandViewModel
{
    [Required] public string? Name { get; set; }

    [Required] public string? Description { get; set; }
}