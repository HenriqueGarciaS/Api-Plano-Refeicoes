using APIPlanoDeReficoes.Context;
using APIPlanoDeReficoes.Models;
using Microsoft.EntityFrameworkCore;

namespace APIPlanoDeReficoes.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context) { }

        public override async Task<IEnumerable<Patient>> GetAll()
        {

            var patients = await _context.Patients.AsNoTracking().ToListAsync();
            return patients.Where(p => p.Deleted == false);
        }

        public override async Task<Patient?> GetById(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null || patient.Deleted == true)
                return null;
            return patient;
        }

        public override async Task<Patient> DeleteById(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            patient.Deleted = true;
            _context.Patients.Update(patient);
            return patient;
        }

    }
}
