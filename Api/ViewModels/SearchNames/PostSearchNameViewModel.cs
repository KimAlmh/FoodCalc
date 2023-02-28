using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.SearchNames;

public class PostSearchNameViewModel
{
    [Required] public string Name { get; set; } = null!;
}