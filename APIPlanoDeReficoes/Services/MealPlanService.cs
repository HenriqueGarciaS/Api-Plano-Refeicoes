using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Models;
using APIPlanoDeReficoes.Repositories;

namespace APIPlanoDeReficoes.Services;

public class MealPlanService : IMealPlanService
{
    private readonly IMealPlanRepository _mealPlanRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IFoodRepository _foodRepository;

    public MealPlanService(IMealPlanRepository mealPlanRepository, IPatientRepository patientRepository, IFoodRepository foodRepository)
    {
        _mealPlanRepository = mealPlanRepository;
        _patientRepository = patientRepository;
        _foodRepository = foodRepository;
    }

    public async Task<IEnumerable<MealPlanDto>> GetAll(int page)
    {
        var mealPlans = await _mealPlanRepository.GetAll(page);
        var mealPlanDtos = new List<MealPlanDto>();
        foreach (var mealPlan in mealPlans)
        {
            mealPlanDtos.Add(new MealPlanDto(mealPlan));
        }

        return mealPlanDtos;
    }

    public async Task<MealPlanDto> GetById(int id)
    {
        var mealPlan = await _mealPlanRepository.GetById(id);
        return new MealPlanDto(mealPlan);
    }

    public async Task<MealPlan> Add(MealPlanDto mealPlanDto, int patientId)
    {
        var mealPlan = new MealPlan();
        var patient = await _patientRepository.GetById(patientId);
        var foodsOfPlan = mealPlanDto.Foods;

        foreach (var food in foodsOfPlan)
        {
            var foodToBeAdded = await _foodRepository.GetFoodByName(food.Name);
            mealPlan.Foods.Add(foodToBeAdded);
        }

        mealPlan.Patient = patient;
        mealPlan.Name = mealPlanDto.Name;
        mealPlan.DayOfWeek = mealPlanDto.DayOfWeek;

        await _mealPlanRepository.Create(mealPlan);
        return mealPlan;
    }

    public async Task<MealPlanDto?> Update(MealPlanDto mealPlanDto, int id)
    {
        var mealPlan = await _mealPlanRepository.GetById(id);
        if (mealPlan == null)
            return null;
        mealPlan.Name = mealPlanDto.Name;
        mealPlan.DayOfWeek = mealPlanDto.DayOfWeek;
        
        var foods = await _foodRepository.GetAll(1);
        var foodsOfPlan = new List<Food>();
        foreach (var mealPlanFood in mealPlanDto.Foods)
            foodsOfPlan.Add(foods.FirstOrDefault(f => f.Name == mealPlanFood.Name));
        mealPlan.Foods = foodsOfPlan;
        
        return new MealPlanDto(mealPlan);
    }

    public async Task<MealPlanDto> Delete(int id)
    {
        var mealPlan = await _mealPlanRepository.DeleteById(id);
        var mealPlanDto = new MealPlanDto(mealPlan);
        return mealPlanDto;
    }

    public async Task<MealPlanDto> GetMealPlanByDay(DayOfWeek day, int patientId)
    {
        var mealPlan = await _mealPlanRepository.GetByDay(day, patientId);
        return new MealPlanDto(mealPlan);
    }
    
}