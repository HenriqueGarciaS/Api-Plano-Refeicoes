using APIPlanoDeReficoes.Models;
using APIPlanoDeReficoes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIPlanoDeReficoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _repository;

        public PatientController(IPatientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id:int}", Name = "GetPatient")]
        public async Task<ActionResult<Patient>> GetById(int id)
        {
            var patient =  await _repository.GetById(id);

            if (patient == null)
                return NotFound("Patient not found");

            return Ok(patient); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAll()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest();

            var createdPatient = await _repository.Create(patient);
            return new CreatedAtRouteResult("GetPatient", new { id = createdPatient.Id }, createdPatient);
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<Patient>> UpdatePatient([FromBody] Patient patient, int id)
        {
            if(id != patient.Id)
                return BadRequest();
            await _repository.Update(patient);
            return Ok(patient);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Patient>> DeleteById(int id) 
        { 
            var deletedPatient = await _repository.DeleteById(id);
            return Ok(deletedPatient);
        }
    }
}
