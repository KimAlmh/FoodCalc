using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public class FoodPerPieceRepository : BaseCrudRepository<FoodPerPiece>, IFoodPerPieceRepository
{
    public FoodPerPieceRepository(FoodCalcContext context) : base(context)
    {
    }

    public async Task<IEnumerable<FoodPerPiece>> GetAllFoodPerPieces()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<IEnumerable<FoodPerPiece>> GetAllFoodPerPiecesByFoodPerGramId(int id)
    {
        return await GetAllByCondition(food => food.FoodPerGram!.Id == id).ToListAsync();
    }

    public async Task<FoodPerPiece> GetFoodPerPieceById(int id)
    {
        return await GetByCondition(foodPerPiece => foodPerPiece.Id.Equals(id));
    }

    public async Task CreateFoodPerPiece(FoodPerPiece foodPerPiece)
    {
        await Create(foodPerPiece);
    }

    public void UpdateFoodPerPiece(FoodPerPiece foodPerPiece)
    {
        Update(foodPerPiece);
    }

    public void DeleteFoodPerPiece(FoodPerPiece foodPerPiece)
    {
        Delete(foodPerPiece);
    }
}