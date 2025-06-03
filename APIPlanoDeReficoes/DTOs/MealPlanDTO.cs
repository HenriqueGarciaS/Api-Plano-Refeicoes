using System.Text.Json.Serialization;
using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.DTOs;

public class MealPlanDto
{
    public string? Name { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public ICollection<FoodDto> Foods { get; set; } = new List<FoodDto>();
    public long TotalOfCalories { get; set; }
    
    public MealPlanDto(){}
    public MealPlanDto(MealPlan mealPlan)
    {
        Name = mealPlan.Name;
        DayOfWeek = mealPlan.DayOfWeek;
        foreach (Food food in mealPlan.Foods)
        {
            var foodDto = new FoodDto(food);
            Foods.Add(foodDto);
            TotalOfCalories += foodDto.Calories.Value;
        }
    }
}