using System.ComponentModel.DataAnnotations;
using Api.Interfaces;
using Api.Utils;
using Api.ViewModels.Pieces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/food/")]
[ApiController]
public class PieceController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repository;

    public PieceController(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("{foodId}/pieces", Name = "GetPieceByFoodId")]
    public async Task<IActionResult> GetPiecesByFoodIdAsync(int foodId)
    {
        var piece = await _repository.Piece.GetAllPiecesByFoodId(foodId);
        return Ok(_mapper.Map<List<SimplePieceViewModel>>(piece));
    }

    [HttpGet("{foodId}/piece/{pieceId}")]
    public async Task<IActionResult> GetCalculatedFoodAsync(int foodId, int pieceId)
    {
        var piece = await _repository.Piece.GetPieceById(pieceId);
        piece.Food = FoodUtil.MultiplyByWeight(piece!.Food, piece.Weight);
        return Ok(_mapper.Map<PieceViewModel>(piece));
    }

    [HttpGet("calculate")]
    public async Task<IActionResult> CalculateFoodAsync([Required] int foodId, [Required] double weight)
    {
        var piece = await _repository.Piece.GetPieceByFoodId(foodId);
        piece!.Weight = weight;
        piece.Food = FoodUtil.MultiplyByWeight(piece.Food, piece.Weight);
        return Ok(_mapper.Map<PieceViewModel>(piece));
    }

    [HttpGet("piece")]
    public async Task<IActionResult> ListPiecesAsync()
    {
        return Ok(await _repository.Piece.GetAllPieces());
    }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeletePieceAsync(int id)
    // {
    //     
    // }
}