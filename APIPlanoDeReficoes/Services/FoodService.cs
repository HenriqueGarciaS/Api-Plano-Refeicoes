using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Models;
using APIPlanoDeReficoes.Repositories;

namespace APIPlanoDeReficoes.Services;

public class FoodService : IFoodService
{
    private readonly IRepository<Food> _repository;

    public FoodService(IRepository<Food> repository)
    {
        _repository = repository;
    }


    public async Task<IEnumerable<FoodDto>> GetAll(int page)
    {
        var foods = await _repository.GetAll(page);
        var foodDtos = new List<FoodDto>();
        foreach(var food in foods)
            foodDtos.Add(new FoodDto(food));
        return foodDtos;
    }

    public async Task<FoodDto> GetById(int id)
    {
        var food = await _repository.GetById(id);
        return new FoodDto(food);
    }

    public async Task<Food> CreateFood(FoodDto foodDto)
    {
        var food = new Food(foodDto);
        var createdFood = await _repository.Create(food);
        return createdFood;
    }

    public async Task<FoodDto?> UpdateFood(FoodDto foodDto, int id)
    {
        var food = await _repository.GetById(id);
        if (food == null)
            return null;
        food.Name = foodDto.Name;
        food.Calories = foodDto.Calories;
        food.SizeOfPortion = foodDto.SizeOfPortion.Value;
        return foodDto;
    }

    public async Task<FoodDto> DeleteFood(int id)
    {
        var food = await _repository.DeleteById(id);
        var foodDto = new FoodDto(food);
        return foodDto;
    }
}