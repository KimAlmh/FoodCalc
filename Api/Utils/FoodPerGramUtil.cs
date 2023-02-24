using Api.Models;
using Api.ViewModels.FoodPerGrams;

namespace Api.Utils;

public static class FoodPerGramUtil
{
    public static FoodPerGram? MultiplyBy100(FoodPerGram? model)
    {
        model.Kcal = Math.Round(model.Kcal * 100, 3);
        model.Kj = Math.Round(model.Kj * 100, 3);
        model.Carbohydrate = Math.Round(model.Carbohydrate * 100, 3);
        model.Fat = Math.Round(model.Fat * 100, 3);
        model.Protein = Math.Round(model.Protein * 100, 3);
        model.Sugar = Math.Round(model.Sugar * 100, 3);
        model.Fibre = Math.Round(model.Fibre * 100, 3);
        model.SaturatedFat = Math.Round(model.SaturatedFat * 100, 3);
        model.Salt = Math.Round(model.Salt * 100, 3);
        return model;
    }

    public static FoodPerGram DivideBy100(FoodPerGram model)
    {
        model.Kcal /= 100;
        model.Kj /= 100;
        model.Carbohydrate /= 100;
        model.Fat /= 100;
        model.Protein /= 100;
        model.Sugar /= 100;
        model.Fibre /= 100;
        model.SaturatedFat /= 100;
        model.Salt /= 100;
        return model;
    }
}