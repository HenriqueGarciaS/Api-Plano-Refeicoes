using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Repositories;
using Microsoft.AspNetCore.Mvc;
using APIPlanoDeReficoes.Models;
using APIPlanoDeReficoes.Services;

namespace APIPlanoDeReficoes.Controllers;

[ApiController]
[Route("[controller]")]
public class MealPlansController : ControllerBase
{
    private readonly IMealPlanService _mealPlanService;

    public MealPlansController(IMealPlanService mealPlanService)
    {
        _mealPlanService = mealPlanService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MealPlan>>> GetMealPlans()
    {
        return Ok(await _mealPlanService.GetAll());
    }

    [HttpGet("{id:int}", Name = "GetMealPlanById")]
    public async Task<ActionResult<MealPlan>> GetMealPlan(int id)
    {
        return Ok(await _mealPlanService.GetById(id));
    }

    [HttpPost("{id:int}")]
    public async Task<ActionResult<MealPlan>> CreateMealPlan([FromBody] MealPlanDto mealPlan, int id)
    {
        var mealPlanCreated = await _mealPlanService.Add(mealPlan, id);
        return new CreatedAtRouteResult("GetMealPlanById", new { id = mealPlanCreated.Id }, mealPlanCreated);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateMealPlan(int id, [FromBody] MealPlanDto mealPlan)
    {
        await _mealPlanService.Update(mealPlan,id);
        return Ok(mealPlan);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteMealPlan(int id)
    {
        var mealPlan = await _mealPlanService.Delete(id);
        return Ok(mealPlan);
    }
}