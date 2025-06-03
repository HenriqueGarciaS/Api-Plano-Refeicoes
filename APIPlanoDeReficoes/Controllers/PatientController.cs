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
        public ActionResult<Patient> GetById(int id)
        {
            var patient = _repository.GetById(id);

            if (patient == null)
                return NotFound("Patient not found");

            return Ok(patient); 
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public ActionResult Create([FromBody] Patient patient)
        {
            if (patient == null)
                return BadRequest();

            var createdPatient = _repository.Create(patient);
            return new CreatedAtRouteResult("GetPatient", new { id = createdPatient.Id }, createdPatient);
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Patient> UpdatePatient([FromBody] Patient patient, int id)
        {
            if(id != patient.Id)
                return BadRequest();
            _repository.Update(patient);
            return Ok(patient);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Patient> DeleteById(int id) 
        { 
            var deletedPatient = _repository.DeleteById(id);
            return Ok(deletedPatient);
        }
    }
}
