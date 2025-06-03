using APIPlanoDeReficoes.Models;
using APIPlanoDeReficoes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIPlanoDeReficoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IRepository<Food> _repository;

        public FoodsController(IRepository<Food> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id:int}", Name = "GetFood")]
        public async Task<ActionResult<Food>> GetById(int id)
        {
            return Ok(await _repository.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Food>> Post([FromBody] Food food)
        {
            await _repository.Create(food);
            return new CreatedAtRouteResult("GetFood", new { id = food.Id }, food);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Food>> Put(int id, [FromBody] Food food)
        {
            if(food.Id != id)
                return BadRequest();
            await _repository.Update(food);
            return Ok(food);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Food>> Delete(int id)
        {
            var food = await _repository.DeleteById(id);
            return food;
        }



    }
}
