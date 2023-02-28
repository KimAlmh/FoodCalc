using Api.Enums;
using Api.Models;
using Api.ViewModels.Food;
using AutoMapper;

namespace Api.Utils;

public static class FoodUtil
{

    public static Food FormatToEntity(PostFoodViewModel model, IMapper mapper)
    {
        if (model.Type == "PD") model.Pieces = null;
        
        var food = mapper.Map<Food>(model);
        return (model.Type switch
        {
            "G1" or "PD" => food,
            "G100" => DivideBy100(food),
            _ => throw new ArgumentException("Invalid type: " + model.Type)
        })!;
    }
    public static FoodViewModel FormatToViewModel(Food food, double weight, IMapper mapper)
    {
        if (food.FoodType == FoodType.Gram)
        {
            food = MultiplyByWeight(food, weight);
        }
        
        return mapper.Map<FoodViewModel>(food);
    }
    public static Food MultiplyBy100(Food model)
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

    public static Food MultiplyByWeight(Food model, double weight)
    {
        model.Kcal = Math.Round(model.Kcal * weight, 3);
        model.Kj = Math.Round(model.Kj * weight, 3);
        model.Carbohydrate = Math.Round(model.Carbohydrate * weight, 3);
        model.Fat = Math.Round(model.Fat * weight, 3);
        model.Protein = Math.Round(model.Protein * weight, 3);
        model.Sugar = Math.Round(model.Sugar * weight, 3);
        model.Fibre = Math.Round(model.Fibre * weight, 3);
        model.SaturatedFat = Math.Round(model.SaturatedFat * weight, 3);
        model.Salt = Math.Round(model.Salt * weight, 3);
        return model;
    }
}