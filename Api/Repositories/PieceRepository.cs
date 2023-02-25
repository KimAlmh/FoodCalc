using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class PieceRepository : BaseCrudRepository<Piece>, IPieceRepository
{
    public PieceRepository(FoodCalcContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Piece>> GetAllPieces()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<IEnumerable<Piece>> GetAllPiecesByFoodId(int id)
    {
        return await GetAllByCondition(food => food.Food!.Id == id).ToListAsync();
    }

    public async Task<Piece?> GetPieceById(int id)
    {
        return await GetByCondition(foodPerPiece => foodPerPiece.Id.Equals(id));
    }

    public async Task<Piece?> GetPieceByFoodIdAndWeight(int id, double weight)
    {
        return await GetByCondition(foodPerPiece => foodPerPiece.Weight.Equals(weight) && foodPerPiece.FoodId.Equals(id));
    }

    public async Task CreatePiece(Piece piece)
    {
        await Create(piece);
    }

    public async Task CreateAllPieces(List<Piece> foodPerPieces)
    {
        foreach (var foodPerPiece in foodPerPieces)
        {
             await CreatePiece(foodPerPiece);
        }
    }

    public void UpdatePiece(Piece piece)
    {
        Update(piece);
    }

    public void DeleteFoodPerPiece(Piece piece)
    {
        Delete(piece);
    }
}