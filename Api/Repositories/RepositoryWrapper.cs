using Api.Data;
using Api.Interfaces;

namespace Api.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly FoodCalcContext _repoContext;
    private IBrandRepository? _brand;
    private IFoodPerGramRepository? _foodPerGram;
    private IFoodPerPieceRepository? _foodPerPiece;

    public RepositoryWrapper(FoodCalcContext repositoryContext)
    {
        _repoContext = repositoryContext;
    }

    public async Task<bool> Save()
    {
        return await _repoContext.SaveChangesAsync() > 0;
    }

    public IBrandRepository Brand => _brand ??= _brand = new BrandRepository(_repoContext);

    public IFoodPerGramRepository FoodPerGram =>
        _foodPerGram ??= _foodPerGram = new FoodPerGramRepository(_repoContext);

    public IFoodPerPieceRepository FoodPerPiece =>
        _foodPerPiece ??= _foodPerPiece = new FoodPerPieceRepository(_repoContext);
}