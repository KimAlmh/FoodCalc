using Api.Interfaces;
using Api.Models;
using Api.ViewModels.Brands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repository;

    public BrandController(IRepositoryWrapper repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrandAsync(PostBrandViewModel model)
    {
        var brand = _mapper.Map<Brand>(model);
        await _repository.Brand.CreateBrand(brand);

        if (!await _repository.Save()) return StatusCode(500, "Failed to add Brand");

        var viewModel = _mapper.Map<BrandViewModel>(brand);
        return CreatedAtRoute("GetByBrandId", new { id = brand.Id }, viewModel);
    }

    [HttpGet("{id}", Name = "GetByBrandId")]
    public async Task<IActionResult> GetBrandByIdAsync(int id)
    {
        return Ok(_mapper.Map<BrandViewModel>(await _repository.Brand.GetBrandById(id)));
    }

    [HttpGet("name/{name}", Name = "GetByName")]
    public async Task<IActionResult> GetAllBrandsByNameAsync(string name)
    {
        return Ok(_mapper.Map<List<BrandViewModel>>(await _repository.Brand.GetAllBrandsByName(name)));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBrandsAsync()
    {
        return Ok(_mapper.Map<List<BrandViewModel>>(await _repository.Brand.GetAllBrands()));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        _repository.Brand.DeleteBrand(await _repository.Brand.GetBrandById(id));
        if (await _repository.Save()) return NoContent();

        return StatusCode(500, "Failed to delete Brand with id: " + id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBrandAsync([FromBody] PostBrandViewModel model, int id)
    {
        var brand = await _repository.Brand.GetBrandById(id);
        _mapper.Map(model, brand);
        _repository.Brand.UpdateBrand(brand);
        if (await _repository.Save()) return NoContent();
        return StatusCode(500, "Failed to update Food Per Gram with id: " + id);
    }
}