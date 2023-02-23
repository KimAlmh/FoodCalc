// using Api.Data;
// using Api.Enums;
// using Api.Interfaces;
// using Api.Models;
// using Api.ViewModels.FoodPerPieces;
// using AutoMapper;
// using Microsoft.EntityFrameworkCore;
//
// namespace Api.Repositories;
//
// public class FoodPerPieceRepository : BaseCrudRepository<FoodPerPiece>, IFoodPerPieceRepository
// {
//     public FoodPerPieceRepository(FoodCalcContext context) : base(context)
//     {
//     }
//
//     public async Task<bool> SaveAllAsync() => await _context.SaveChangesAsync() > 0;
//
//     public async Task<FoodPerPiece> CreateFoodPerPieceAsync(PostFoodPerPieceViewModel model)
//     {
//         var brand = await _brandRepository.GetBrandByName(model.Brand);
//         model = (model.PieceType == PieceType.G100) ? MultiplyByWeight(model) : model;
//         var foodPerPiece = _mapper.Map<FoodPerPiece>(model);
//         foodPerPiece.Brand = brand;
//         await _context.FoodPerPieces.AddAsync(foodPerPiece);
//         return foodPerPiece;
//     }
//
//     public async Task<FoodPerPiece> GetFoodPerPieceAsync(int id)
//     {
//         var foodPerPiece = await _context.FoodPerPieces
//             .Include(i => i.Brand)
//             .FirstOrDefaultAsync(f => f.Id == id) ?? throw new ArgumentException("No food per piece with that id: " + id);
//         return foodPerPiece;
//     }
//
//     public async Task<IEnumerable<FoodPerPiece>> ListFoodPerPiecesAsync() => 
//         await _context.FoodPerPieces.Include(i => i.Brand).ToListAsync();
//     
//
//     public async Task DeleteFoodPerPieceAsync(int id)
//     {
//         var foodPerPiece = await _context.FoodPerPieces.FindAsync(id) ??
//                           throw new ArgumentException("No food per piece with id: " + id);
//         _context.Remove(foodPerPiece);
//     }
//
//     private PostFoodPerPieceViewModel MultiplyByWeight(PostFoodPerPieceViewModel model)
//     {
//         var weightMultiplier = model.Weight / 100;
//         model.Kcal = Math.Round(model.Kcal * weightMultiplier, 3);
//         model.Kj = Math.Round(model.Kj * weightMultiplier, 3);
//         model.Carbohydrate = Math.Round(model.Carbohydrate * weightMultiplier, 3);
//         model.Fat = Math.Round(model.Fat * weightMultiplier, 3);
//         model.Protein = Math.Round(model.Protein * weightMultiplier, 3);
//         model.Sugar = Math.Round(model.Sugar * weightMultiplier, 3);
//         model.Fibre = Math.Round(model.Fibre * weightMultiplier, 3);
//         model.SaturatedFat = Math.Round(model.SaturatedFat * weightMultiplier, 3);
//         model.Salt = Math.Round(model.Salt * weightMultiplier, 3);
//         return model;
//     }
// }