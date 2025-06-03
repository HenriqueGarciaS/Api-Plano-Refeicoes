using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APIPlanoDeReficoes.DTOs;

namespace APIPlanoDeReficoes.Models
{
    [Table("Foods")]
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(120)]
        public string? Name { get; set; }
        [Required]
        public long? Calories { get; set; }
        [Required]
        public long? SizeOfPortion { get; set; }

        public Food()
        {
        }

        public Food(FoodDto foodDto)
        {
            Name = foodDto.Name;
            Calories = foodDto.Calories;
            SizeOfPortion = foodDto.SizeOfPortion.Value;
        }

    }
}
