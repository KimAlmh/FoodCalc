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
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

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

        if (await _repository.Save())
        {
            var viewModel = _mapper.Map<BrandViewModel>(brand);
            return CreatedAtRoute("GetById", new { id = brand.Id }, viewModel);
        }

        return StatusCode(500, "Failed to add Brand");
    }

    [HttpGet("{id}", Name = "GetById")]
    public async Task<IActionResult> GetBrandByIdAsync(int id)
    {
        return Ok(_mapper.Map<BrandViewModel>(await _repository.Brand.GetBrandById(id)));
    }

    [HttpGet("name/{name}", Name = "GetByName")]
    public async Task<IActionResult> GetBrandByNameAsync(string name)
    {
        return Ok(_mapper.Map<BrandViewModel>(await _repository.Brand.GetBrandByName(name)));
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
}