using System.Collections.ObjectModel;
using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.DTOs;

public class PatientDto
{
    public string? Name { get; set; }
    public string? Email { get; set; }

    public bool Deleted { get; set; }
    public ICollection<MealPlanDto> MealPlans { get; set; } = new Collection<MealPlanDto>();

    public PatientDto()
    {
        
    }
    public PatientDto(Patient patient)
    {
        Name = patient.Name;
        Email = patient.Email;
        Deleted = patient.Deleted;
        foreach (var mealPlan in patient.MealPlans)
        {
            var mealPlanDto = new MealPlanDto(mealPlan);
            MealPlans.Add(mealPlanDto);
        }
    }
    
}