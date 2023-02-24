namespace Api.Interfaces;

public interface IRepositoryWrapper
{
    IBrandRepository Brand { get; }
    IFoodPerPieceRepository FoodPerPiece { get; }
    IFoodPerGramRepository FoodPerGram { get; }
    ISearchNameRepository SearchName { get; }
    Task<bool> Save();
    void Clear();
}