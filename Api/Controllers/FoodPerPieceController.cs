using Api.Interfaces;
using Api.Models;
using Api.Utils;
using Api.ViewModels.FoodPerPieces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/food/piece")]
[ApiController]
public class FoodPerPieceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repository;

    public FoodPerPieceController(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // [HttpPost]
    // public async Task<IActionResult> CreateFoodPerPieceAsync(PostFoodPerPieceViewModel model)
    // {
    //     var foodPerPiece = _mapper.Map<FoodPerPiece>(model);
    //     foodPerPiece = model.PieceType == "PC" ? FoodPerPieceUtil.MultiplyByWeight(foodPerPiece) : foodPerPiece;
    //     foodPerPiece.Brand = await _repository.Brand.GetBrandById(model.BrandId);
    //
    //     await _repository.FoodPerPiece.CreateFoodPerPiece(foodPerPiece);
    //     if (!await _repository.Save()) return StatusCode(500, "Could not add Food Per Piece");
    //
    //     var viewModel = _mapper.Map<FoodPerPieceViewModel>(foodPerPiece);
    //     return CreatedAtRoute("GetPieceById", new { id = foodPerPiece.Id }, viewModel);
    // }
    //
    // [HttpGet("{id}", Name = "GetPieceById")]
    // public async Task<IActionResult> GetFoodPerPieceByIdAsync(int id)
    // {
    //     return Ok(_mapper.Map<FoodPerPieceViewModel>(await _repository.FoodPerPiece.GetFoodPerPieceById(id)));
    // }
    //
    // [HttpGet("name/{name}", Name = "GetPieceByName")]
    // public async Task<IActionResult> GetAllFoodPerPiecesByNameAsync(string name)
    // {
    //     return Ok(_mapper.Map<FoodPerPieceViewModel>(await _repository.FoodPerPiece.GetAllFoodPerPiecesByName(name)));
    // }
    //
    // [HttpGet]
    // public async Task<IActionResult> ListFoodPerPiecesAsync()
    // {
    //     return Ok(_mapper.Map<List<FoodPerPieceViewModel>>(await _repository.FoodPerPiece.GetAllFoodPerPieces()));
    // }
    //
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteFoodPerPieceAsync(int id)
    // {
    //     _repository.FoodPerPiece.DeleteFoodPerPiece(await _repository.FoodPerPiece.GetFoodPerPieceById(id));
    //     if (await _repository.Save()) return NoContent();
    //     return StatusCode(500, "Failed to delete Food Per Piece with id: " + id);
    // }
}