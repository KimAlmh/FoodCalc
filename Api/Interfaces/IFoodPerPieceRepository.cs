using Api.Models;
using Api.ViewModels.FoodPerPieces;

namespace Api.Interfaces;

public interface IFoodPerPieceRepository
{
    public Task<bool> SaveAllAsync();
    public Task<FoodPerPiece> CreateFoodPerPieceAsync(PostFoodPerPieceViewModel model);
    public Task<FoodPerPieceViewModel> GetFoodPerPieceAsync(int id);
    public Task<List<FoodPerPieceViewModel>> ListFoodPerPiecesAsync();
    public Task DeleteFoodPerPieceAsync(int id);
}