// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Api.Helpers;
// using Api.Interfaces;
// using Api.ViewModels.FoodPerPieces;
// using AutoMapper;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
//
// namespace Api.Controllers
// {
//     [Route("api/food/piece")]
//     [ApiController]
//     public class FoodPerPieceController : ControllerBase
//     {
//         private readonly IMapper _mapper;
//         private readonly IFoodPerPieceRepository _foodPerPieceRepository;
//
//         public FoodPerPieceController(IFoodPerPieceRepository foodPerPieceRepository, IMapper mapper)
//         {
//             _mapper = mapper;
//             _foodPerPieceRepository = foodPerPieceRepository;
//         }
//
//         [HttpPost]
//         public async Task<IActionResult> CreateFoodPerPieceAsync(PostFoodPerPieceViewModel model)
//         {
//             var foodPerPiece = await _foodPerPieceRepository.CreateFoodPerPieceAsync(model);
//             var viewFoodPerPiece = _mapper.Map<FoodPerPieceViewModel>(foodPerPiece);
//
//             if (await _foodPerPieceRepository.SaveAllAsync())
//             {
//                 return Created($"https://localhost:{AppData.Configuration!["port"]}/api/foodPerPiece/{foodPerPiece.Id}",
//                     viewFoodPerPiece);
//             }
//
//             return StatusCode(500, "Could not add FoodPerPiece");
//         }
//
//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetFoodPerPieceAsync(int id) =>
//             Ok(await _foodPerPieceRepository.GetFoodPerPieceAsync(id));
//
//         [HttpGet()]
//         public async Task<IActionResult> ListFoodPerPiecesAsync() =>
//             Ok(await _foodPerPieceRepository.ListFoodPerPiecesAsync());
//
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteFoodPerPieceAsync(int id)
//         {
//             await _foodPerPieceRepository.DeleteFoodPerPieceAsync(id);
//             if (await _foodPerPieceRepository.SaveAllAsync())
//             {
//                 return NoContent();
//             }
//
//             return StatusCode(500, "Failed to delete Food Per Piece with id: " + id);
//         }
//     }
// }