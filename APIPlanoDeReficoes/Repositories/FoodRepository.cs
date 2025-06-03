using APIPlanoDeReficoes.Context;
using APIPlanoDeReficoes.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPlanoDeReficoes.Repositories;

public class FoodRepository : Repository<Food>, IFoodRepository
{
    public FoodRepository(AppDbContext context) : base(context) { }

    public async Task<Food?> GetFoodByName(string foodName)
    {
        return await _context.Foods.FirstOrDefaultAsync(f => f.Name == foodName);
    }
}