using Api.Models;

namespace Api.Interfaces;

public interface IFoodPerPieceRepository
{
    Task<IEnumerable<FoodPerPiece>> GetAllFoodPerPieces();
    Task<IEnumerable<FoodPerPiece>> GetAllFoodPerPiecesByFoodPerGramId(int id);
    Task<FoodPerPiece?> GetFoodPerPieceById(int id);
    Task CreateFoodPerPiece(FoodPerPiece brand);
    Task CreateAllFoodPerPiece(List<FoodPerPiece> foodPerPieces);
    void UpdateFoodPerPiece(FoodPerPiece brand);
    void DeleteFoodPerPiece(FoodPerPiece brand);
}