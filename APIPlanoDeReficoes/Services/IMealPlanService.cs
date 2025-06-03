using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.Services;

public interface IMealPlanService
{
    Task<IEnumerable<MealPlanDto>> GetAll();
    Task<MealPlanDto> GetById(int id);
    Task<MealPlan> Add(MealPlanDto mealPlanDto, int patientId);
    Task<MealPlanDto> Update(MealPlanDto mealPlanDto, int id);
    Task<MealPlanDto> Delete(int id);
}