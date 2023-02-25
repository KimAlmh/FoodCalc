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

    public async Task<IEnumerable<Piece>> GetAllPiecesByFoodId(int foodId)
    {
        return await GetAllByCondition(piece => piece.FoodId == foodId).Include(i => i.Food).ThenInclude(f => f!.Brand).ToListAsync();
    }

    public async Task<Piece?> GetPieceById(int id)
    {
        return await GetAllByCondition(piece => piece.Id.Equals(id)).Include(p => p.Food).ThenInclude(f => f!.Brand)
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("No Piece with that id");
    }
    
    public async Task<Piece?> GetPieceByFoodId(int foodId)
    {
        return await GetAllByCondition(piece => piece.FoodId.Equals(foodId)).Include(p => p.Food).ThenInclude(f => f!.Brand)
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("No Piece with that id");
    }

    public async Task<Piece?> GetPieceByFoodIdAndWeight(int foodId, double weight)
    {
        return await GetAllByCondition(piece => piece.Weight.Equals(weight) && piece.FoodId.Equals(foodId))
            .FirstOrDefaultAsync();
    }

    public async Task CreatePiece(Piece piece)
    {
        await Create(piece);
    }

    public async Task CreateAllPieces(List<Piece> pieces)
    {
        foreach (var piece in pieces) await CreatePiece(piece);
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