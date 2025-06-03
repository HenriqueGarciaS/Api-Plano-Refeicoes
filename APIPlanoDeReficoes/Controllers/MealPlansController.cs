using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Repositories;
using Microsoft.AspNetCore.Mvc;
using APIPlanoDeReficoes.Models;
using APIPlanoDeReficoes.Services;
using APIPlanoDeReficoes.Enums;
using Microsoft.AspNetCore.Authorization;

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

    [Authorize(Roles = nameof(Role.NUTRITIONIST))]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MealPlan>>> GetMealPlans([FromQuery] int page = 1)
    {
        return Ok(await _mealPlanService.GetAll(page));
    }

    [Authorize(Roles = nameof(Role.NUTRITIONIST))]
    [HttpGet("{id:int}", Name = "GetMealPlanById")]
    public async Task<ActionResult<MealPlan>> GetMealPlan(int id)
    {
        return Ok(await _mealPlanService.GetById(id));
    }

    [Authorize(Roles = nameof(Role.NUTRITIONIST))]
    [HttpPost("{patientId:int}")]
    public async Task<ActionResult<MealPlan>> CreateMealPlan([FromBody] MealPlanDto mealPlan, int patientId)
    {
        var mealPlanCreated = await _mealPlanService.Add(mealPlan, patientId);
        return new CreatedAtRouteResult("GetMealPlanById", new { id = mealPlanCreated.Id }, mealPlanCreated);
    }

    [Authorize(Roles = nameof(Role.NUTRITIONIST))]
    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateMealPlan(int id, [FromBody] MealPlanDto mealPlan)
    {
        await _mealPlanService.Update(mealPlan,id);
        return Ok(mealPlan);
    }

    [Authorize(Roles = nameof(Role.NUTRITIONIST))]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteMealPlan(int id)
    {
        var mealPlan = await _mealPlanService.Delete(id);
        return Ok(mealPlan);
    }
}