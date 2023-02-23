using Api.Models;

namespace Api.Interfaces;

public interface IFoodPerGramRepository
{
    Task<IEnumerable<FoodPerGram>> GetAllFoodPerGrams();
    Task<IEnumerable<FoodPerGram>> GetAllFoodPerGramsByName(string name);
    Task<FoodPerGram> GetFoodPerGramById(int id);
    Task CreateFoodPerGram(FoodPerGram brand);
    void UpdateFoodPerGram(FoodPerGram brand);
    void DeleteFoodPerGram(FoodPerGram brand);
}