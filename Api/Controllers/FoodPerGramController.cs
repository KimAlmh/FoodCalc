using Api.Interfaces;
using Api.Models;
using Api.Utils;
using Api.ViewModels.FoodPerGrams;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
        foodPerGram = model.GramType == "G100" ? FoodPerGramUtil.MultiplyBy100(foodPerGram) : foodPerGram;
        foodPerGram.Brand = await _repository.Brand.GetBrandById(model.BrandId);
        await _repository.FoodPerGram.CreateFoodPerGram(foodPerGram);

        if (!await _repository.Save()) return StatusCode(500, "Could not add Food Per Gram");

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
        foodsPerGram.ToList().ForEach(food => food = FoodPerGramUtil.MultiplyBy100(food));
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
}