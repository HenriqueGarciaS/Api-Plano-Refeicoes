using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.Services;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetAll(int page);
    Task<PatientDto> GetById(int id);
    Task<Patient> Add(PatientDto patient);
    Task<PatientDto> Update(PatientDto patientDto, int id);
    Task<PatientDto> Delete(int id);
    Task<MealPlanDto> GetMealPlanOfToday(int id);
}