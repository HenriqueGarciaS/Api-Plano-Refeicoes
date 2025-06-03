using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Enums;
using APIPlanoDeReficoes.Models;
using APIPlanoDeReficoes.Repositories;
using APIPlanoDeReficoes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIPlanoDeReficoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDto>>> GetAll([FromQuery] int page = 1)
        {
            return Ok(await _foodService.GetAll(page));
        }

        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpGet("{id:int}", Name = "GetFood")]
        public async Task<ActionResult<FoodDto>> GetById(int id)
        {
            return Ok(await _foodService.GetById(id));
        }

        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpPost]
        public async Task<ActionResult<Food>> Post([FromBody] FoodDto food)
        {
            var createdFood = await _foodService.CreateFood(food);
            return new CreatedAtRouteResult("GetFood", new { id = createdFood.Id }, createdFood);
        }


        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<FoodDto>> Put(int id, [FromBody] FoodDto food)
        {
            await _foodService.UpdateFood(food,id);
            return Ok(food);
        }

        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<FoodDto>> Delete(int id)
        {
            var food = await _foodService.DeleteFood(id);
            return food;
        }



    }
}
