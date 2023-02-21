using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Api.Interfaces;
using Api.ViewModels.FoodPerGrams;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/food/gram")]
    [ApiController]
    public class FoodPerGramController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFoodPerGramRepository _foodPerGramRepository;

        public FoodPerGramController(IFoodPerGramRepository foodPerGramRepository, IMapper mapper)
        {
            _mapper = mapper;
            _foodPerGramRepository = foodPerGramRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFoodPerGramAsync(PostFoodPerGramViewModel model)
        {
            try
            {
                var foodPerGram = await _foodPerGramRepository.CreateFoodPerGramAsync(model);
                var viewFoodPerGram = _mapper.Map<FoodPerGramViewModel>(foodPerGram);

                if (await _foodPerGramRepository.SaveAllAsync())
                {
                    return Created($"https://localhost:{AppData.Configuration!["port"]}/api/foodPerGram/{foodPerGram.Id}", viewFoodPerGram);
                }

                return StatusCode(500, "Could not add FoodPerGram");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodPerGramAsync(int id)
        {
            try
            {
                return Ok(await _foodPerGramRepository.GetFoodPerGramAsync(id));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet()]
        public async Task<IActionResult> ListFoodPerGramsAsync()
        {
            try
            {
                return Ok(await _foodPerGramRepository.ListFoodPerGramsAsync());
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
                await _foodPerGramRepository.DeleteFoodPerGramAsync(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
