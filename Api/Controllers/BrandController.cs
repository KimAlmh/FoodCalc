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
            try
            {
                var brand = await _brandRepository.CreateBrandAsync(model);
                var viewBrand = _mapper.Map<BrandViewModel>(brand);

                if (await _brandRepository.SaveAllAsync())
                {
                    return Created($"https://localhost:{AppData.Configuration!["port"]}/api/brand/{brand.Id}", viewBrand);
                }

                return StatusCode(500, "Could not add Brand");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandAsync(int id)
        {
            try
            {
                return Ok(await _brandRepository.GetBrandAsync(id));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        

        [HttpGet()]
        public async Task<IActionResult> ListBrandsAsync()
        {
            try
            {
                return Ok(await _brandRepository.ListBrandsAsync());
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ListBrandesSimpleAsync(int id)
        {
            try
            {
                await _brandRepository.DeleteBrandAsync(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
