using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIPlanoDeReficoes.Models
{
    [Table("Meal_Plans")]
    public class MealPlan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string? Name { get; set; }
        [Required]
        public DayOfWeek DayOfWeek { get; set; }
        public ICollection<Food> Foods { get; set; }
        [Required]
        public int sizeOfPortion { get; set; }
        [JsonIgnore]
        public Patient? Patient { get; set; }


        public MealPlan()
        {
            Foods = new Collection<Food>();
        }


    }
}
