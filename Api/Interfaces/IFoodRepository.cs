using Api.Models;

namespace Api.Interfaces;

public interface IFoodRepository
{
    Task<IEnumerable<Food?>> GetAllFoods();
    Task<IEnumerable<Food>> GetAllFoodsByName(string name);
    Task<Food?> GetFoodById(int id);
    Task<Food?> GetFoodByNameAndBrandId(string name, int brandId);
    Task CreateFood(Food brand);
    Task<bool> CheckIfExistsByNameAndBrandId(string name, int brandId);
    void UpdateFood(Food brand);
    void DeleteFood(Food brand);
}