using Api.Models;

namespace Api.Utils;

public static class FoodPerPieceUtil
{
    public static FoodPerPiece MultiplyByWeight(FoodPerPiece model)
    {
        var weightMultiplier = model.Weight / 100;
        model.Kcal = Math.Round(model.Kcal * weightMultiplier, 3);
        model.Kj = Math.Round(model.Kj * weightMultiplier, 3);
        model.Carbohydrate = Math.Round(model.Carbohydrate * weightMultiplier, 3);
        model.Fat = Math.Round(model.Fat * weightMultiplier, 3);
        model.Protein = Math.Round(model.Protein * weightMultiplier, 3);
        model.Sugar = Math.Round(model.Sugar * weightMultiplier, 3);
        model.Fibre = Math.Round(model.Fibre * weightMultiplier, 3);
        model.SaturatedFat = Math.Round(model.SaturatedFat * weightMultiplier, 3);
        model.Salt = Math.Round(model.Salt * weightMultiplier, 3);
        return model;
    }
}