using APIPlanoDeReficoes.DTOs;
using APIPlanoDeReficoes.Models;
using APIPlanoDeReficoes.Repositories;
using APIPlanoDeReficoes.Services;
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

        [HttpGet("{id:int}", Name = "GetPatient")]
        public async Task<ActionResult<Patient>> GetById(int id)
        {
            var patient =  await _patientService.GetById(id);

            if (patient == null)
                return NotFound("Patient not found");

            return Ok(patient); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAll()
        {
            return Ok(await _patientService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PatientDto patient)
        {
            if (patient == null)
                return BadRequest();

            var createdPatient = await _patientService.Add(patient);
            return new CreatedAtRouteResult("GetPatient", new { id = createdPatient.Id }, createdPatient);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<PatientDto>> UpdatePatient([FromBody] PatientDto patient, int id)
        {
            var p = await _patientService.Update(patient,id);
            if (p == null)
                return BadRequest();
            return Ok(patient);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PatientDto>> DeleteById(int id) 
        { 
            var deletedPatient = await _patientService.Delete(id);
            return Ok(deletedPatient);
        }

        //Todo
        [HttpGet("{id:int}/mealplans/today")]
        public async Task<ActionResult> GetTodayMealPlan(int id)
        {
            return Ok();
        }
    }
}
