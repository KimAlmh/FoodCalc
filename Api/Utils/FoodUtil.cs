using Api.Models;
using Api.ViewModels.FoodPerGrams;

namespace Api.Utils;

public static class FoodUtil
{
    public static Food? MultiplyBy100(Food? model)
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

    public static Food DivideBy100(Food model)
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
    public static Piece MultiplyByWeight(Piece model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        var weightMultiplier = model.Weight / 100;
        model.Food.Kcal = Math.Round(model.Food.Kcal * weightMultiplier, 3);
        model.Food.Kj = Math.Round(model.Food.Kj * weightMultiplier, 3);
        model.Food.Carbohydrate = Math.Round(model.Food.Carbohydrate * weightMultiplier, 3);
        model.Food.Fat = Math.Round(model.Food.Fat * weightMultiplier, 3);
        model.Food.Protein = Math.Round(model.Food.Protein * weightMultiplier, 3);
        model.Food.Sugar = Math.Round(model.Food.Sugar * weightMultiplier, 3);
        model.Food.Fibre = Math.Round(model.Food.Fibre * weightMultiplier, 3);
        model.Food.SaturatedFat = Math.Round(model.Food.SaturatedFat * weightMultiplier, 3);
        model.Food.Salt = Math.Round(model.Food.Salt * weightMultiplier, 3);
        return model;
    }
}