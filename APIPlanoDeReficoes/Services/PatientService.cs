using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Repositories;
using APIPlanoDeReficoes.Models;

namespace APIPlanoDeReficoes.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;

    public PatientService(IPatientRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PatientDto>> GetAll()
    {
        var patients = await _repository.GetAll();
        var patientsDtos = new List<PatientDto>();
        foreach (var patient in patients)
        {
            patientsDtos.Add(new PatientDto(patient));
        }
        return patientsDtos;
    }

    public async Task<PatientDto?> GetById(int id)
    {
        var patient = await _repository.GetById(id);
        var patientDto = new PatientDto(patient);
        return patientDto;
        
    }

    public async Task<Patient> Add(PatientDto patientDto)
    {
        var patient = new Patient(patientDto);
        await _repository.Create(patient);
        return patient;
    }

    public async Task<PatientDto?> Update(PatientDto patientDto, int id)
    {
        var patient = await _repository.GetById(id);
        if (patient == null)
            return null;
        patient.Name = patientDto.Name;
        patient.Email = patientDto.Email;
        patient.Deleted = patientDto.Deleted;
        await _repository.Update(patient);
        return patientDto;
    }

    public async Task<PatientDto> Delete(int id)
    {

        var patient = await _repository.DeleteById(id);
        var patientDto = new PatientDto(patient);
        return patientDto;

    }
    
}