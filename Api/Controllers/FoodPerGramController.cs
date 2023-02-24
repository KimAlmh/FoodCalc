using Api.Interfaces;
using Api.Models;
using Api.Utils;
using Api.ViewModels.FoodPerGrams;
using Api.ViewModels.FoodPerPieces;
using Api.ViewModels.SearchNames;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers;

[Route("api/food/gram")]
[ApiController]
public class FoodPerGramController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repository;

    public FoodPerGramController(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFoodPerGramAsync(PostFoodPerGramViewModel model)
    {
        var foodPerGram = _mapper.Map<FoodPerGram>(model);
        foodPerGram = model.GramType == "G100" ? FoodPerGramUtil.DivideBy100(foodPerGram) : foodPerGram;
        foodPerGram.Brand = await _repository.Brand.GetBrandById(model.BrandId);
        await _repository.FoodPerGram.CreateFoodPerGram(foodPerGram);
        if (!await _repository.Save()) return StatusCode(500, "Could not add Food Per Gram");

        if (!model.SearchNames.IsNullOrEmpty())
            await AddSearchNameToFoodPerGram(new PostSearchNameViewModel { Names = model.SearchNames },
                foodPerGram.Id);
        
        if (!model.PieceWeights.IsNullOrEmpty())
            await AddPieceToFoodPerGram(new PostFoodPerPieceViewModel { Weights = model.PieceWeights },
                foodPerGram.Id);


        var viewModel = _mapper.Map<FoodPerGramViewModel>(foodPerGram);
        return CreatedAtRoute("GetByGramId", new { id = foodPerGram.Id }, viewModel);
    }

    [HttpGet("{id}", Name = "GetByGramId")]
    public async Task<IActionResult> GetFoodPerGramAsync(int id)
    {
        var foodPerGram = await _repository.FoodPerGram.GetFoodPerGramById(id);
        foodPerGram = FoodPerGramUtil.MultiplyBy100(foodPerGram);
        return Ok(_mapper.Map<FoodPerGramViewModel>(foodPerGram));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFoodPerGramsAsync()
    {
        var foodsPerGram = await _repository.FoodPerGram.GetAllFoodPerGrams();
        foodsPerGram.ToList().ForEach(food => FoodPerGramUtil.MultiplyBy100(food));
        return Ok(_mapper.Map<List<FoodPerGramViewModel>>(foodsPerGram));
    }

    [HttpGet("name/{name}", Name = "GetByGramName")]
    public async Task<IActionResult> GetAllFoodPerGramsByNameAsync(string name)
    {
        return Ok(_mapper.Map<List<FoodPerGramViewModel>>(
            await _repository.FoodPerGram.GetAllFoodPerGramsByName(name)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFoodPerPieceAsync(int id)
    {
        _repository.FoodPerGram.DeleteFoodPerGram(await _repository.FoodPerGram.GetFoodPerGramById(id));

        if (await _repository.Save()) return NoContent();
        return StatusCode(500, "Failed to delete Food Per Gram with id: " + id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFoodPerGramAsync(PostFoodPerGramViewModel model, int id)
    {
        var foodPerGram = await _repository.FoodPerGram.GetFoodPerGramById(id);
        foodPerGram.Brand = await _repository.Brand.GetBrandById(model.BrandId);
        _repository.FoodPerGram.UpdateFoodPerGram(foodPerGram);
        if (await _repository.Save()) return NoContent();
        return StatusCode(500, "Failed to update Food Per Gram with id: " + id);
    }

    [HttpPatch("search/{id}")]
    public async Task<IActionResult> AddSearchNameToFoodPerGram(PostSearchNameViewModel model, int id)
    {
        var foodPerGram = await _repository.FoodPerGram.GetFoodPerGramById(id);
        var searchNames = model.Names!
            .Select(name => _mapper.Map<SearchName>(new SearchName { Name = name, FoodPerGram = foodPerGram }))
            .ToList();
        await _repository.SearchName.CreateAllSearchNames(searchNames);
        var alreadyExistsCount = 0;
        var createdCount = 0;
        foreach (var searchName in searchNames)
        {
            try
            {
                await _repository.SearchName.CreateSearchName(searchName);
                if (await _repository.Save()) createdCount++;
            }
            catch (DbUpdateException e)
            {
                if (!e.InnerException!.Message.ToLower().Contains("duplicate key")) throw;
                
                alreadyExistsCount++;
                _repository.SearchName.DeleteSearchName(searchName);
                Console.WriteLine("duplicate, skipping");
            }
        }

        if (createdCount == 0) return StatusCode(500, "Failed to add Search Names to Food Per Gram with id: " + id);
        HttpContext.Response.Headers.Add("updated-count", createdCount.ToString());
        HttpContext.Response.Headers.Add("already-existed-count", alreadyExistsCount.ToString());
        return NoContent();
    }

    [HttpPatch("piece/{id}")]
    public async Task<IActionResult> AddPieceToFoodPerGram(PostFoodPerPieceViewModel model, int id)
    {
        var foodPerGram = await _repository.FoodPerGram.GetFoodPerGramById(id);
        var foodPerPieces = model.Weights!
            .Select(weight =>
                _mapper.Map<FoodPerPiece>(new FoodPerPiece { Weight = weight, FoodPerGram = foodPerGram }))
            .ToList();
        var alreadyExistsCount = 0;
        var createdCount = 0;
        foreach (var foodPerPiece in foodPerPieces)
        {
            try
            {
                await _repository.FoodPerPiece.CreateFoodPerPiece(foodPerPiece);
                if (await _repository.Save()) createdCount++;
            }
            catch (DbUpdateException e)
            {
                if (!e.InnerException!.Message.ToLower().Contains("duplicate key")) throw;
                
                _repository.FoodPerPiece.DeleteFoodPerPiece(foodPerPiece);
                alreadyExistsCount++;
                Console.WriteLine("duplicate, skipping");
            }
        }

        if (createdCount == 0 && alreadyExistsCount == 0) return StatusCode(500, "Failed to add piece weights to Food Per Gram with id: " + id);
        HttpContext.Response.Headers.Add("updated-count", createdCount.ToString());
        HttpContext.Response.Headers.Add("already-existed-count", alreadyExistsCount.ToString());
        return NoContent();

    }
}