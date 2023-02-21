using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Api.Interfaces;
using Api.ViewModels.Brands;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository, IMapper mapper)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrandAsync(PostBrandViewModel model)
        {
            var brand = await _brandRepository.CreateBrandAsync(model);
            var viewBrand = _mapper.Map<BrandViewModel>(brand);

            if (await _brandRepository.SaveAllAsync())
            {
                return Created($"https://localhost:{AppData.Configuration!["port"]}/api/brand/{brand.Id}", viewBrand);
            }

            return StatusCode(500, "Failed to add Brand");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandAsync(int id) => 
            Ok(await _brandRepository.GetBrandAsync(id));

        [HttpGet()]
        public async Task<IActionResult> ListBrandsAsync() => 
            Ok(await _brandRepository.ListBrandsAsync());

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandRepository.DeleteBrandAsync(id);
            if (await _brandRepository.SaveAllAsync())
            {
                return NoContent();
            }

            return StatusCode(500, "Failed to delete Brand with id: " + id);
        }
    }
}