using Api.Models;

namespace Api.Interfaces;

public interface IFoodPerPieceRepository
{
    public Task<bool> SaveAllAsync();
    public Task<FoodPerPiece> CreateFoodPerPieceAsync(PostFoodPerPieceViewModel model);
    public Task<FoodPerPieceViewModel> GetFoodPerPieceAsync(int id);
    public Task<List<FoodPerPieceViewModel>> ListFoodPerPieceAsync();
    public Task DeleteFoodPerPieceAsync(int id);
}