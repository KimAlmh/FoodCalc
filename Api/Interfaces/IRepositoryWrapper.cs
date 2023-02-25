namespace Api.Interfaces;

public interface IRepositoryWrapper
{
    IBrandRepository Brand { get; }
    IPieceRepository Piece { get; }
    IFoodRepository Food { get; }
    ISearchNameRepository SearchName { get; }
    Task<bool> Save();
}