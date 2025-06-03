using APIPlanoDeReficoes.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPlanoDeReficoes.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
