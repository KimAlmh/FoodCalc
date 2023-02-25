using Api.Models;

namespace Api.Interfaces;

public interface IPieceRepository
{
    Task<IEnumerable<Piece>> GetAllPieces();
    Task<IEnumerable<Piece>> GetAllPiecesByFoodId(int id);
    Task<Piece?> GetPieceById(int id);
    Task<Piece?> GetPieceByFoodId(int foodId);
    Task<Piece?> GetPieceByFoodIdAndWeight(int id, double weight);
    Task CreatePiece(Piece brand);
    Task CreateAllPieces(List<Piece> foodPerPieces);
    void UpdatePiece(Piece brand);
    void DeleteFoodPerPiece(Piece brand);
}