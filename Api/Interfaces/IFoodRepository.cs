using Api.Models;

namespace Api.Interfaces;

public interface IFoodRepository
{
    Task<IEnumerable<Food?>> GetAllFoods();
    Task<IEnumerable<Food>> GetAllFoodsByName(string name);
    Task<Food> GetFoodById(int id);
    Task CreateFood(Food brand);
    void UpdateFood(Food brand);
    void DeleteFood(Food brand);
    Task CheckConstraint(string name, int brandId);
}