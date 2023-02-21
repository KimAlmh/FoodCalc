using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Helpers;
using Api.Interfaces;
using Api.ViewModels.FoodPerPieces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/food/piece")]
    [ApiController]
    public class FoodPerPieceController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFoodPerPieceRepository _foodPerPieceRepository;

        public FoodPerPieceController(IFoodPerPieceRepository foodPerPieceRepository, IMapper mapper)
        {
            _mapper = mapper;
            _foodPerPieceRepository = foodPerPieceRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFoodPerPieceAsync(PostFoodPerPieceViewModel model)
        {
            try
            {
                var foodPerPiece = await _foodPerPieceRepository.CreateFoodPerPieceAsync(model);
                var viewFoodPerPiece = _mapper.Map<FoodPerPieceViewModel>(foodPerPiece);

                if (await _foodPerPieceRepository.SaveAllAsync())
                {
                    return Created($"https://localhost:{AppData.Configuration!["port"]}/api/foodPerPiece/{foodPerPiece.Id}", viewFoodPerPiece);
                }

                return StatusCode(500, "Could not add FoodPerPiece");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodPerPieceAsync(int id)
        {
            try
            {
                return Ok(await _foodPerPieceRepository.GetFoodPerPieceAsync(id));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet()]
        public async Task<IActionResult> ListFoodPerPiecesAsync()
        {
            try
            {
                return Ok(await _foodPerPieceRepository.ListFoodPerPiecesAsync());
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
                await _foodPerPieceRepository.DeleteFoodPerPieceAsync(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
