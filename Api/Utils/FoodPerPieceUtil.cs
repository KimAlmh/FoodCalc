using Api.Models;

namespace Api.Utils;

public static class FoodPerPieceUtil
{
    public static FoodPerPiece MultiplyByWeight(FoodPerPiece model)
    {
        var weightMultiplier = model.Weight / 100;
        model.FoodPerGram.Kcal = Math.Round(model.FoodPerGram.Kcal * weightMultiplier, 3);
        model.FoodPerGram.Kj = Math.Round(model.FoodPerGram.Kj * weightMultiplier, 3);
        model.FoodPerGram.Carbohydrate = Math.Round(model.FoodPerGram.Carbohydrate * weightMultiplier, 3);
        model.FoodPerGram.Fat = Math.Round(model.FoodPerGram.Fat * weightMultiplier, 3);
        model.FoodPerGram.Protein = Math.Round(model.FoodPerGram.Protein * weightMultiplier, 3);
        model.FoodPerGram.Sugar = Math.Round(model.FoodPerGram.Sugar * weightMultiplier, 3);
        model.FoodPerGram.Fibre = Math.Round(model.FoodPerGram.Fibre * weightMultiplier, 3);
        model.FoodPerGram.SaturatedFat = Math.Round(model.FoodPerGram.SaturatedFat * weightMultiplier, 3);
        model.FoodPerGram.Salt = Math.Round(model.FoodPerGram.Salt * weightMultiplier, 3);
        return model;
    }
}