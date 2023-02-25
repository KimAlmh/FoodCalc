using Api.Interfaces;
using Api.Models;
using Api.Utils;
using Api.ViewModels.FoodPerGrams;
using Api.ViewModels.Pieces;
using Api.ViewModels.SearchNames;
using AutoMapper;
using FoodCalcApi.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers;

[Route("api/food/")]
[ApiController]
public class FoodController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repository;

    public FoodController(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFoodAsync(PostFoodViewModel model)
    {
        await _repository.Food.CheckConstraint(model.Name, model.BrandId);

        var food = _mapper.Map<Food>(model);
        food = model.GramType == "G100" ? FoodUtil.DivideBy100(food) : food;
        food.Brand = await _repository.Brand.GetBrandById(model.BrandId);

        await _repository.Food.CreateFood(food);
        if (!await _repository.Save()) return StatusCode(500, "Could not add Food");

        if (!model.SearchNames.IsNullOrEmpty())
            await AddSearchNamesToFoodPerGram(new PostSearchNameViewModel { Names = model.SearchNames },
                food.Id);

        if (!model.Pieces.IsNullOrEmpty())
            await AddPiecesToFoodPerGram(model.Pieces, food.Id);

        var viewModel = _mapper.Map<FoodViewModel>(food);
        return CreatedAtRoute("GetByFoodId", new { id = food.Id }, viewModel);
    }

    [HttpGet("{id}", Name = "GetByFoodId")]
    public async Task<IActionResult> GetFoodAsync(int id)
    {
        var food = await _repository.Food.GetFoodById(id);
        food = FoodUtil.MultiplyBy100(food);
        return Ok(_mapper.Map<FoodViewModel>(food));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFoodPerGramsAsync()
    {
        var foodsPerGram = await _repository.Food.GetAllFoods();
        foodsPerGram.ToList().ForEach(food => FoodUtil.MultiplyBy100(food));
        return Ok(_mapper.Map<List<FoodViewModel>>(foodsPerGram));
    }

    [HttpGet("name/{name}", Name = "GetByGramName")]
    public async Task<IActionResult> GetAllFoodPerGramsByNameAsync(string name)
    {
        return Ok(_mapper.Map<List<FoodViewModel>>(
            await _repository.Food.GetAllFoodsByName(name)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFoodPerPieceAsync(int id)
    {
        _repository.Food.DeleteFood(await _repository.Food.GetFoodById(id));

        if (await _repository.Save()) return NoContent();
        return StatusCode(500, "Failed to delete Food with id: " + id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFoodAsync(PostFoodViewModel model, int id)
    {
        var food = await _repository.Food.GetFoodById(id);
        food!.Brand = await _repository.Brand.GetBrandById(model.BrandId);
        _repository.Food.UpdateFood(food);
        if (await _repository.Save()) return NoContent();
        return StatusCode(500, "Failed to update Food with id: " + id);
    }

    [HttpPatch("{id}/search")]
    public async Task<IActionResult> AddSearchNamesToFoodPerGram(PostSearchNameViewModel model, int id)
    {
        var food = await _repository.Food.GetFoodById(id);
        var searchNames = new List<SearchName>();
        var duplicateCount = 0;
        foreach (var name in model.Names!)
        {
            var searchName = new SearchName { Name = name, Food = food };
            if (await _repository.SearchName.GetSearchNameByNameAndFoodId(id, name) == null)
                searchNames.Add(searchName);
            else duplicateCount++;
        }

        await _repository.SearchName.CreateAllSearchNames(searchNames);
        if (duplicateCount > 0 && searchNames.Count == 0)
            return Ok(new { added = searchNames.Count, duplicates = duplicateCount });
        if (await _repository.Save())
            return CreatedAtRoute("GetByFoodId", new { id = food!.Id },
                new { added = searchNames.Count, duplicates = duplicateCount });

        return StatusCode(500, "Failed to add search names to Food with id: " + id);
    }

    [HttpPatch("{id}/piece")]
    public async Task<IActionResult> AddPiecesToFoodPerGram(ICollection<PostPieceViewModel> models, int id)
    {
        var food = await _repository.Food.GetFoodById(id);
        var pieces = new List<Piece>();
        var duplicateCount = 0;
        foreach (var piece in models!)
        {
            var pieceToAdd = new Piece { Weight = piece.Weight, Name = piece.Name, Food = food };
            if (await _repository.Piece.GetPieceByFoodIdAndWeight(id, piece.Weight) == null)
                pieces.Add(pieceToAdd);
            else duplicateCount++;
        }

        await _repository.Piece.CreateAllPieces(pieces);
        if (duplicateCount > 0 && pieces.Count == 0)
            return Ok(new { added = pieces.Count, duplicates = duplicateCount });
        if (await _repository.Save())
            return CreatedAtRoute("GetByFoodId", new { id = food!.Id },
                new { added = pieces.Count, duplicates = duplicateCount });

        return StatusCode(500, "Failed to add search name to Food with id: " + id);
    }
}