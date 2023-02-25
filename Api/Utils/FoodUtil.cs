using Api.Models;

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
        model.Food!.Kcal = Math.Round(model.Food.Kcal * model.Weight, 3);
        model.Food.Kj = Math.Round(model.Food.Kj * model.Weight, 3);
        model.Food.Carbohydrate = Math.Round(model.Food.Carbohydrate * model.Weight, 3);
        model.Food.Fat = Math.Round(model.Food.Fat * model.Weight, 3);
        model.Food.Protein = Math.Round(model.Food.Protein * model.Weight, 3);
        model.Food.Sugar = Math.Round(model.Food.Sugar * model.Weight, 3);
        model.Food.Fibre = Math.Round(model.Food.Fibre * model.Weight, 3);
        model.Food.SaturatedFat = Math.Round(model.Food.SaturatedFat * model.Weight, 3);
        model.Food.Salt = Math.Round(model.Food.Salt * model.Weight, 3);
        return model;
    }
}