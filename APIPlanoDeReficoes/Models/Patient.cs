using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APIPlanoDeReficoes.DTOs;

namespace APIPlanoDeReficoes.Models
{
    [Table("Patients")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength (80)]
        public string? Name { get; set; }

        [Required]
        [StringLength(80)]
        public string? Email { get; set; }
        

        public ICollection<MealPlan> MealPlans { get; set; }

        public bool Deleted { get; set; } = false;

        public Patient()
        {
            MealPlans = new Collection<MealPlan>();
        }

        public Patient(PatientDto patientDto)
        {
            Name = patientDto.Name;
            Email = patientDto.Email;
            Deleted = patientDto.Deleted;
            MealPlans = new Collection<MealPlan>();
        }

    }
}
