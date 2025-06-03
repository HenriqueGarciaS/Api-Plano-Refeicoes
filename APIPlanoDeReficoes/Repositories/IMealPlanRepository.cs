using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.Repositories;

public interface IMealPlanRepository : IRepository<MealPlan>
{
    Task<IEnumerable<MealPlan>> GetAll(int page);
    Task<MealPlan> GetById(int id);
    Task<MealPlan> GetByDay(DayOfWeek day, int patientId);
}