using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels.SearchNames;

public class PostSearchNameViewModel
{
    [Required] public IEnumerable<string>? Names { get; set; }
}