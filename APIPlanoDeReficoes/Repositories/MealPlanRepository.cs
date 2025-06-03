using APIPlanoDeReficoes.Context;
using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPlanoDeReficoes.Repositories;

public class MealPlanRepository : Repository<MealPlan>, IMealPlanRepository
{
    public MealPlanRepository(AppDbContext context) : base(context) { }
    
    public override async  Task<IEnumerable<MealPlan>> GetAll()
    {
        return await _context.MealPlans.Include(m => m.Foods).AsNoTracking().ToListAsync();
        
    }

    public override async Task<MealPlan> GetById(int id)
    {
        return await _context.MealPlans.Include(m => m.Foods).FirstOrDefaultAsync(m => m.Id == id);
    }
    
}