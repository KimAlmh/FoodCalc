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
            var foodPerGram = await _foodPerGramRepository.CreateFoodPerGramAsync(model);
            var viewFoodPerGram = _mapper.Map<FoodPerGramViewModel>(foodPerGram);

            if (await _foodPerGramRepository.SaveAllAsync())
            {
                return Created($"https://localhost:{AppData.Configuration!["port"]}/api/foodPerGram/{foodPerGram.Id}",
                    viewFoodPerGram);
            }

            return StatusCode(500, "Could not add FoodPerGram");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodPerGramAsync(int id) =>
            Ok(await _foodPerGramRepository.GetFoodPerGramAsync(id));
        
        [HttpGet()]
        public async Task<IActionResult> ListFoodPerGramsAsync() =>
            Ok(await _foodPerGramRepository.ListFoodPerGramsAsync());
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodPerPieceAsync(int id)
        {
            await _foodPerGramRepository.DeleteFoodPerGramAsync(id);
            if (await _foodPerGramRepository.SaveAllAsync())
            {
                return NoContent();
            }

            return StatusCode(500, "Failed to delete Food Per Piece with id: " + id);
        }
    }
}