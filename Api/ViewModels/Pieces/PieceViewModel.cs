using System.Text.Json.Serialization;

namespace Api.ViewModels.Pieces;

public class PieceViewModel
{
    public int Id { get; set; }
    public double Weight { get; set; }
    [JsonPropertyName("name")]public string Name { get; set; } = null!;

    [JsonPropertyName("foodName")] public string FoodName { get; set; } = null!;

    [JsonPropertyName("brandName")] public string FoodBrandName { get; set; } = null!;

    [JsonPropertyName("kcal")] public double FoodKcal { get; set; }

    [JsonPropertyName("kj")] public double FoodKj { get; set; }

    [JsonPropertyName("carbohydrate")] public double FoodCarbohydrate { get; set; }

    [JsonPropertyName("fat")] public double FoodFat { get; set; }

    [JsonPropertyName("protein")] public double FoodProtein { get; set; }

    [JsonPropertyName("sugar")] public double FoodSugar { get; set; }

    [JsonPropertyName("fibre")] public double FoodFibre { get; set; }

    [JsonPropertyName("saturatedFat")] public double FoodSaturatedFat { get; set; }

    [JsonPropertyName("salt")] public double FoodSalt { get; set; }
}