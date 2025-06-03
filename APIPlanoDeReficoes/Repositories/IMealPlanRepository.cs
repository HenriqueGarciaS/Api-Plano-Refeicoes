using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.Repositories;

public interface IMealPlanRepository : IRepository<MealPlan>
{
    Task<IEnumerable<MealPlan>> GetAll();
    Task<MealPlan> GetById(int id);
}