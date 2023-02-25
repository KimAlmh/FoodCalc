using Api.Data;
using Api.Interfaces;

namespace Api.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly FoodCalcContext _repoContext;
    private IBrandRepository? _brand;
    private IFoodRepository? _food;
    private IPieceRepository? _piece;
    private ISearchNameRepository? _searchName;

    public RepositoryWrapper(FoodCalcContext repositoryContext)
    {
        _repoContext = repositoryContext;
    }

    public async Task<bool> Save()
    {
        return await _repoContext.SaveChangesAsync() > 0;
    }

    public IBrandRepository Brand => _brand ??= _brand = new BrandRepository(_repoContext);

    public IFoodRepository Food =>
        _food ??= _food = new FoodRepository(_repoContext);

    public ISearchNameRepository SearchName =>
        _searchName ??= _searchName = new SearchNameRepository(_repoContext);

    public IPieceRepository Piece =>
        _piece ??= _piece = new PieceRepository(_repoContext);
}