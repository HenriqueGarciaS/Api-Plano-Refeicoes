using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Enums;
using APIPlanoDeReficoes.Models;
using APIPlanoDeReficoes.Repositories;
using APIPlanoDeReficoes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIPlanoDeReficoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpGet("{id:int}", Name = "GetPatient")]
        public async Task<ActionResult<Patient>> GetById(int id)
        {
            var patient =  await _patientService.GetById(id);

            if (patient == null)
                return NotFound("Patient not found");

            return Ok(patient); 
        }

        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAll(int page = 1)
        {
            return Ok(await _patientService.GetAll(page));
        }

        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PatientDto patient)
        {
            if (patient == null)
                return BadRequest();

            var createdPatient = await _patientService.Add(patient);
            return new CreatedAtRouteResult("GetPatient", new { id = createdPatient.Id }, createdPatient);
        }

        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<PatientDto>> UpdatePatient([FromBody] PatientDto patient, int id)
        {
            var p = await _patientService.Update(patient,id);
            if (p == null)
                return BadRequest();
            return Ok(patient);
        }

        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PatientDto>> DeleteById(int id) 
        { 
            var deletedPatient = await _patientService.Delete(id);
            return Ok(deletedPatient);
        }

        [Authorize(Roles = nameof(Role.ADMIN))]
        [HttpGet("{id:int}/mealplans/today")]
        public async Task<ActionResult<MealPlanDto>> GetTodayMealPlan(int id)
        {
            var mealPlan =  await _patientService.GetMealPlanOfToday(id);
            return Ok(mealPlan);
        }
    }
}
