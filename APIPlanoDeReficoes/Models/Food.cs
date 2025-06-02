using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    }
}
