using System.Drawing;
using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.DTOs;

public class FoodDto
{
    public string? Name { get; set; }
    public long? Calories { get; set; }
    public long? SizeOfPortion { get; set; }

    public FoodDto()
    {
    }

    public FoodDto(Food food)
    {
        Name = food.Name;
        Calories = food.Calories;
        SizeOfPortion = food.SizeOfPortion;
    }
}