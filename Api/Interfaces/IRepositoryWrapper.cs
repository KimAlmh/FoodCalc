namespace Api.Interfaces;

public interface IRepositoryWrapper
{
    IBrandRepository Brand { get; }
    IFoodPerPieceRepository FoodPerPiece { get; }
    IFoodPerGramRepository FoodPerGram { get; }
    Task<bool> Save();
}