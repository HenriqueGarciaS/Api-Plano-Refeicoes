using APIPlanoDeReficoes.Context;
using APIPlanoDeReficoes.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPlanoDeReficoes.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context) { }

        public override IEnumerable<Patient> GetAll()
        {
            return _context.Patients.AsNoTracking().ToList().Where(p => p.Deleted == false);
        }

        public override Patient? GetById(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null || patient.Deleted == true)
                return null;
            return patient;
        }

        public override Patient DeleteById(int id)
        {
            var patient = _context.Patients.Find(id);
            patient.Deleted = true;
            _context.Patients.Update(patient);
            return patient;
        }

    }
}
