using Api.Enums;
using Api.ViewModels.Pieces;

namespace Api.ViewModels.Food;

public class FoodViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public double Kcal { get; set; }
    public double Kj { get; set; }
    public double Carbohydrate { get; set; }
    public double Fat { get; set; }
    public double Protein { get; set; }
    public double Sugar { get; set; }
    public double Fibre { get; set; }
    public double SaturatedFat { get; set; }
    public double Salt { get; set; }
    public FoodType FoodType { get; set; }
    public ICollection<string>? SearchNames { get; set; }  = new List<string>();
    public ICollection<SimplePieceViewModel>? Pieces { get; set; }  = new List<SimplePieceViewModel>();
}