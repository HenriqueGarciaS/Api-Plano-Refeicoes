using APIPlanoDeReficoes.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPlanoDeReficoes.Models
{
    [Table("TB_Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Name { get; set; }
        [MaxLength (100)]
        public string? Email { get; set; }
        [MaxLength (100)]
        public string? Password { get; set; }
        public Role Role { get; set; }
    }
}
