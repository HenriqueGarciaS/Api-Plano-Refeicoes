using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.Services;

public interface IFoodService
{
    Task<IEnumerable<FoodDto>> GetAll(int page);
    Task<FoodDto> GetById(int id);
    Task<Food> CreateFood(FoodDto foodDto);
    Task<FoodDto> UpdateFood(FoodDto foodDto, int id);
    Task<FoodDto> DeleteFood(int id);
    
}