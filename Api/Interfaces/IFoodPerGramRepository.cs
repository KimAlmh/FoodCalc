using Api.Models;
using Api.ViewModels.FoodPerGrams;

namespace Api.Interfaces;

public interface IFoodPerGramRepository
{
    public Task<bool> SaveAllAsync();
    public Task<FoodPerGram> CreateFoodPerGramAsync(PostFoodPerGramViewModel model);
    public Task<FoodPerGramViewModel> GetFoodPerGramAsync(int id);
    public Task<List<FoodPerGramViewModel>> ListFoodPerGramsAsync();
    public Task DeleteFoodPerGramAsync(int id);
}