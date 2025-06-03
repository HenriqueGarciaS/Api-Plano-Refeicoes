using APIPlanoDeReficoes.Context;
using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPlanoDeReficoes.Repositories;

public class MealPlanRepository : Repository<MealPlan>, IMealPlanRepository
{
    public MealPlanRepository(AppDbContext context) : base(context) { }
    
    public override async  Task<IEnumerable<MealPlan>> GetAll(int page)
    {
        if (page - 1 <= 0)
            return await _context.MealPlans.Include(m => m.Foods).AsNoTracking().Take(20).ToListAsync();
        
        return await _context.MealPlans.Include(m => m.Foods).AsNoTracking().Skip((page - 1) * 20).Take(20).ToListAsync();
        
    }

    public override async Task<MealPlan> GetById(int id)
    {
        return await _context.MealPlans.Include(m => m.Foods).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<MealPlan> GetByDay(DayOfWeek day, int patientId)
    {
        return await _context.MealPlans.Include(m => m.Foods).AsNoTracking()
            .FirstOrDefaultAsync(m => m.DayOfWeek == day && m.Patient.Id == patientId);
    }
    
}