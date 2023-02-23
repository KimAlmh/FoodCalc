using Api.Data;
using Api.Interfaces;

namespace Api.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private IBrandRepository? _brand;
    private readonly FoodCalcContext _repoContext;
    // private FoodPerGramRepository? _foodPerGram;
    // private FoodPerPieceRepository? _foodPerPiece;

    public async Task<bool> Save() => await _repoContext.SaveChangesAsync() > 0;
    public IBrandRepository Brand => _brand ??= (_brand = new BrandRepository(_repoContext));
    // public IFoodPerGramRepository FoodPerGram => _foodPerGram ??= (_foodPerGram = new FoodPerGramRepository(_repoContext));
    // public IFoodPerPieceRepository FoodPerPiece => _foodPerPiece ??= (_foodPerPiece = new FoodPerPieceRepository(_repoContext));

    // public IFoodPerGramRepository FoodPerGram 
    // { 
    //     get 
    //     { 
    //         if (_foodPerGram == null) 
    //         { 
    //             _foodPerGram = new FoodPerGramRepository(_repoContext); 
    //         } 
    //         return _foodPerGram; 
    //     } 
    // } 
    //
    // public IFoodPerPieceRepository FoodPerPiece 
    // { 
    //     get 
    //     { 
    //         if (_foodPerPiece == null) 
    //         { 
    //             _foodPerPiece = new FoodPerPieceRepository(_repoContext); 
    //         } 
    //         return _foodPerPiece; 
    //     } 
    // } 
    
    public RepositoryWrapper(FoodCalcContext repositoryContext) 
    { 
        _repoContext = repositoryContext; 
    } 

}